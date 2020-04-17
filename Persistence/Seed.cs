using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Clients.Any())
            {
                var clients = new List<Client>
                {
                    new Client
                    {
                        FirstName = "Belvia",
                        LastName = "Kneale",
                        DateOfBirth = DateTime.Now.AddYears(-20),
                        Address = "Pepper Wood",
                        Email = "bkneale0@sourceforge.net"
                    },
                    new Client
                    {
                        FirstName = "Octavia",
                        LastName = "Pullen",
                        DateOfBirth = DateTime.Now.AddYears(-22),
                        Address = "Mallory",
                        Email = "opullen1@feedburner.com"
                    },
                    new Client
                    {
                        FirstName = "Egbert",
                        LastName = "Yerlett",
                        DateOfBirth = DateTime.Now.AddYears(-25),
                        Address = "Stoughton",
                        Email = "eyerlett2@dmoz.org"
                    },
                    new Client
                    {
                        FirstName = "Nil",
                        LastName = "Held",
                        DateOfBirth = DateTime.Now.AddYears(-26),
                        Address = "Grim",
                        Email = "nheld3@amazon.co.uk"
                    },
                    new Client
                    {
                        FirstName = "Cherilynn",
                        LastName = "Ferreras",
                        DateOfBirth = DateTime.Now.AddYears(-30),
                        Address = "Dryden",
                        Email = "cferreras4@moonfruit.com"
                    },
                    new Client
                    {
                        FirstName = "Juliann",
                        LastName = "Alessandrelli",
                        DateOfBirth = DateTime.Now.AddYears(-35),
                        Address = "Sachs",
                        Email = "jalessandrelli5@ameblo.jp"
                    },
                    new Client
                    {
                        FirstName = "Dall",
                        LastName = "Dandison",
                        DateOfBirth = DateTime.Now.AddYears(-20),
                        Address = "Sunfield",
                        Email = "ddandison6@furl.net"
                    },
                    new Client
                    {
                        FirstName = "Maria",
                        LastName = "Pevreal",
                        DateOfBirth = DateTime.Now.AddYears(-42),
                        Address = "Melvin",
                        Email = "mpevreal7@shutterfly.com"
                    },
                    new Client
                    {
                        FirstName = "Katerina",
                        LastName = "Powney",
                        DateOfBirth = DateTime.Now.AddYears(-18),
                        Address = "Kennedy",
                        Email = "kpowney8@instagram.com"
                    }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }
        }
    }
}