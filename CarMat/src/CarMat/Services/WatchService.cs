using CarMat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class WatchService
    {
        private IUnitOfWork _unitOfWork;




        public WatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public void AddNewWatch(int offerId, string username)
        {
            var offer = _unitOfWork.Offers.GetOfferById(offerId);
            var user = _unitOfWork.Users.GetUserIncludingHisOffers(username);

            if (offer != null)
            {
                if (user.Offers.Any(o => o.Id == offer.Id) == false)
                {
                    _unitOfWork.Watches.AddNewWatch(offer, user);
                    _unitOfWork.Complete();
                }
            }
        }

        public void RemoveWatch(int offerId, string username)
        {
            var user = _unitOfWork.Users.GetUserByName(username);
            var offer = _unitOfWork.Offers.GetOfferById(offerId);

            _unitOfWork.Watches.RemoveWatch(offer, user);
            _unitOfWork.Complete();
        }
    }
}
