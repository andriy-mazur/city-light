using CityLight.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace CityLight.Repository
{
    public class CitylightDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Citylight> Citylights { get; set; }
        public DbSet<CitylightSide> CitylightSides { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CitylightDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<CitylightSide>().ToTable("CitylightSides");
            modelBuilder.Entity<Citylight>().ToTable("Citylights");
        }

        public void Seed()
        {
            SeedCitylight();
            SeedCustomer();
        }

        private void SeedCustomer()
        {
            var nameList = File.ReadAllLines(@"..\CityLight.Repository\InitData\Customers.txt");

            var index = 1;
            foreach (var name in nameList)
            {
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                var data = name.Split('|');

                if (data.Length != 4)
                {
                    continue;
                }

                Customers.Add(new Customer
                {
                    Id = index,
                    IsActive = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    ContactPerson = data[0],
                    Name = data[1],
                    Phone = data[2],
                    Email = data[3],                    
                });

                index++;
            }

            SaveChanges();
        }

        private void SeedCitylight()
        {
            // Populate Area
            var area1 = new Area { Id = 1, Created = DateTime.Now, Updated = DateTime.Now, IsActive = true, Name = "Долина" };
            var area2 = new Area { Id = 2, Created = DateTime.Now, Updated = DateTime.Now, IsActive = true, Name = "Вигода" };
            var area3 = new Area { Id = 3, Created = DateTime.Now, Updated = DateTime.Now, IsActive = true, Name = "Дорога", Comment = "Дорога між Долиною та Вигодою" };

            Areas.Add(area1);
            Areas.Add(area2);
            Areas.Add(area3);

            SaveChanges();

            // Populate Sides
            var sideNames = new[] { "пам'ятника Івана Франка", "вулкану", "виставки", "зупинки", "великої калюжі", "аптеки", "кінотеартру", "клубу гурту Kalush", "кладки через калюжу", "торгового центру", "косметичного салону", "кафе \"Долина\"", "колгоспу \"Слава Україні!\"", "клубу фанатів Христини Соловій", "клубу гурту BoomBox", "Богородчан", "моста", "озера", "клубу фанатів Jerry Heil", "моря", "пам'ятника Супермену", "площі", "океану", "поежежної", "пам'ятника Лесі Українки", "магазину", "лісу", "фабрики пошиву трусів", "перукарні", "пам'ятника Олеся Піддерев'янського", "клубу гурту Океан Ельзи", "пам'ятника Шевченка", "дому", "клубу гурту Dzidzo", "Києва", "спортзалу", "парку", "Івано-Франківська", "Кафе \"Смачного!\"", "клубу фанатів Анастасії Приходько", "клубу фанатів Тіни Кароль", "річки", "ганделика", "книгарні", "лісозаготівельної фабрики", "пам'ятника Грушевськогго", "танкового заводу", "Нової Пошти", "базару", "гори", "під'їзду", "Львова", "церкви", "клубми", "пам'ятника Котляру", "гори", "перехрестя", "дороги", "лікарні", "трикотжаної фабрики" };

            var sides = new CitylightSide[sideNames.Length];
            var index = 1;

            foreach (var name in sideNames)
            {
                sides[index - 1] = (new 
                    CitylightSide { 
                    Id = index, 
                    Name = "в сторону " + name, 
                    IsMain = index % 2 == 0 ? SideType.SideA : SideType.SideB });

                CitylightSides.Add(sides[index - 1]);

                index++;
            }

            SaveChanges();

            // Populate Citelites            
            for (var i = 1; i <= 30; i++)
            {
                var area = i <= 17 ? area1 : i <= 27 ? area2 : area3;

                Citylights.Add(new Citylight
                {
                    Id = i,
                    IsActive = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Name = "Сітілайт №" + i,
                    Area = area,
                    Side1 = sides[i * 2 - 2],
                    Side2 = sides[i * 2 - 1]
                });

                index++;
            }

            SaveChanges();
        }
    }
}
