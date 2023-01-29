using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        FriendService friendService = new FriendService();

        public void Show(User user)
        {            
            FriendAddData friendAddData = new FriendAddData();

            Console.Write("\nВведите электронную почту пользователя для добавления в друзья:");
            friendAddData.friend_email = Console.ReadLine();

            friendAddData.user_id = user.Id;
                        
            try
            {
                friendService.AddFrend(friendAddData);
                SuccessMessage.Show("Пользователь успешно добавлен в друзья.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }
        }
    }
}
