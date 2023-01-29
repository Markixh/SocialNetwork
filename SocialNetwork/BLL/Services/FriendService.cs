using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void AddFrend(FriendData friendAddData)
        {
            if (!new EmailAddressAttribute().IsValid(friendAddData.friend_email))
                throw new ArgumentNullException();
                        
            var findFrendEntity = this.userRepository.FindByEmail(friendAddData.friend_email);
            if (friendAddData is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.user_id,
                friend_id = findFrendEntity.id

            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
