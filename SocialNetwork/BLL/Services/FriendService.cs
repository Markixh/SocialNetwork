using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        UserService userService;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userService = new UserService();
            friendRepository = new FriendRepository();
        }

        public void AddFrend(FriendAddData friendAddData)
        {
            if (!new EmailAddressAttribute().IsValid(friendAddData.friend_email))
                throw new ArgumentNullException();

            if (userService.FindByEmail(friendAddData.friend_email) != null)
                throw new ArgumentNullException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.user_id,
                friend_id = userService.FindByEmail(friendAddData.friend_email).Id //доработать
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
