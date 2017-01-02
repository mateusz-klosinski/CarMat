using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private CMContext _context;

        public OfferRepository(CMContext context)
        {
            _context = context;
        }

        public void CreateNewOfferForUser(CMUser user, Offer offer)
        {
            user.Offers.Add(offer);
            _context.Offers.Add(offer);
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Update(offer);
        }

        public void DeleteOffer(Offer offer)
        {
            _context.Remove(offer);
        }

        public OfferDetailsViewModel GetOfferDetails(int offerId)
        {
            return _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Include(o => o.User.Demographics)
                .Include(o => o.User.Demographics.Province)
                .Include(o => o.Vehicle.Model)
                .Include(o => o.Vehicle.Model.Brand)
                .Include(o => o.Vehicle.VehicleVehicleEquipment)
                .Where(o => o.Id == offerId)
                .Select(o => new OfferDetailsViewModel
                {
                    Id = o.Id,
                    DateAdded = o.DateAdded,
                    DateFinished = o.DateFinished,
                    Description = o.Description,
                    Email = o.User.Email,
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    isDamaged = o.Vehicle.isDamaged,
                    isRegistered = o.Vehicle.isRegistered,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    UserName = o.User.UserName,
                    City = o.User.Demographics.City,
                    Province = o.User.Demographics.Province.Name,
                    VehicleBrand = o.Vehicle.Model.Brand.Name,
                    VehicleModel = o.Vehicle.Model.Name,

                    VehicleEquipment = o.Vehicle.VehicleVehicleEquipment
                        .Select(vve => vve.Equipment.Name)
                     .ToList(),
                })
                .FirstOrDefault();
        }

        public List<SimpleOfferViewModel> GetFutureOffers(string username)
        {
            return _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Include(o => o.Watches)
                .Where(o => o.DateFinished > DateTime.Today)
                .Select(o => new SimpleOfferViewModel
                {
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    Id = o.Id,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    IsWatched = o.Watches.Any(w => w.Watcher.UserName.Equals(username)),
                    BelongsToCurrentUser = o.User.UserName.Equals(username)
                })
                .ToList();
        }

        public List<SimpleOfferViewModel> GetOffersWhichBelongsToUser(string username)
        {
            return _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Where(o => o.User.UserName
                .Equals(username))
                .Select(o => new SimpleOfferViewModel
                {
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    Id = o.Id,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    DateFinished = o.DateFinished,
                })
                .ToList();
        }

        public List<SimpleOfferViewModel> GetOffersWatchedByUser(string username)
        {
            var user = _context.Users
                .Where(u => u.UserName.Equals(username))
                .FirstOrDefault();

            return _context.Watches
                .Where(w => w.WatcherId.Equals(user.Id))
                .Include(w => w.WatchedOffer)
                .Select(w => w.WatchedOffer)
                .Select(o => new SimpleOfferViewModel
                {
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    Id = o.Id,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    DateFinished = o.DateFinished,
                })
                .ToList();
        }

        public Offer GetOfferForUser(int offerId, string username)
        {
            return _context.Offers
                    .Include(o => o.Vehicle)
                    .Include(o => o.User)
                    .Include(o => o.Vehicle.VehicleVehicleEquipment)
                    .Where(o => o.Id == offerId && o.User.UserName.Equals(username))
                    .FirstOrDefault();
        }

        public Offer GetOfferById(int offerId)
        {
            return _context.Offers
                .Include(o => o.Watches)
                .ThenInclude(w => w.Watcher)
                .Include(o => o.User)
                .Include(o => o.Vehicle)
                .Include(o => o.Vehicle.Model)
                .Include(o => o.Vehicle.Model.Brand)
                .Where(o => o.Id == offerId)
                .FirstOrDefault();
        }
        
        public OfferFormViewModel GetOfferToEditForUser(string username, int offerId)
        {
            return _context.Offers
                 .Include(o => o.User)
                 .Include(o => o.Vehicle)
                 .Include(o => o.Vehicle.Model)
                 .Include(o => o.Vehicle.Model.Brand)
                 .Include(o => o.Vehicle.VehicleVehicleEquipment)
                 .Where(o => o.User.UserName
                 .Equals(username) && o.Id == offerId)
                 .Select(o => new OfferFormViewModel
                 {
                    Action = "Edit",
                    Id = o.Id,
                    DateFinished = o.DateFinished,
                    Description = o.Description,
                    Price = o.Price.ToString("0"),
                    Title = o.Title,
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    isDamaged = o.Vehicle.isDamaged,
                    isRegistered = o.Vehicle.isRegistered,
                    Mileage = o.Vehicle.Mileage,
                    ProductionYear = o.Vehicle.ProductionYear,
                    VehicleBrand = o.Vehicle.Model.Brand.Name,
                    VehicleModel = o.Vehicle.Model.Name,

                    VehicleEquipment = o.Vehicle.VehicleVehicleEquipment
                        .Select(ve => ve.Equipment.Name).ToList(),
                })
                .FirstOrDefault();
        }


    }
}
