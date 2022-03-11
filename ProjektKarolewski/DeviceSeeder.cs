using ProjektKarolewski.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektKarolewski
{
    public class DeviceSeeder
    {
        private readonly ProjektDbContext _dbContext;

        public DeviceSeeder(ProjektDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                /*if (!_dbContext.Devices.Any())
                {
                    var devices = GetDevices();
                    _dbContext.Devices.AddRange(devices);
                    _dbContext.SaveChanges();
                }*/
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<Device> GetDevices()
        {
            var devices = new List<Device>()
            {
                new Device()
                {
                    Name = "USG",
                    NameInPassport = "USG Aloka ProSound",
                    AcquisitionDate = "2015",
                    ProductionDate = "2012",
                    PassportNumber = "1/1",
                    InventoryNumber = "1/CZM",
                    SerialNumber = "12345678",
                    Comments = "USG takie se",
                    Ward = new Ward()
                    {
                        Name = "Oddział Neurologii"
                    },
                    Inspections = new List<Inspection>()
                    {
                        new Inspection()
                        {
                            InspectionDate = new DateTime(2020, 05, 05),
                            InspectionFrequency = 1,
                            Warranty = true,
                            InspectionType = new InspectionType()
                            {
                                Name = "Okresowe",
                            },
                            Service = new Service()
                            {
                                ServiceName = "Jakub Buba",
                                Street = "Krótka",
                                City = "Warszawa",
                                PostalCode = "22-222",
                                PhoneNumber = "678098345",
                                EmailAddress = "Buba@lol.pl",
                                Contract = new Contract()
                                {
                                    Name = "Zlecenie",
                                }
                            },
                        },
                    },
                    Producer = new Producer()
                    {
                        Name = "Aloka"
                    },
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            TicketDate = new DateTime(2020, 05, 07),
                            TicketDescription = "Uszkodzenie głowicy USG płaskiej",
                            Replies = new List<Reply>()
                            {
                                new Reply()
                                {
                                    ReplyDate = new DateTime(2020,05,09),
                                    ReplyDescription = "Wymieniona głowica na nową"
                                }
                            }
                        }
                    }
                }
            };
            return devices;
        }
    }
}
