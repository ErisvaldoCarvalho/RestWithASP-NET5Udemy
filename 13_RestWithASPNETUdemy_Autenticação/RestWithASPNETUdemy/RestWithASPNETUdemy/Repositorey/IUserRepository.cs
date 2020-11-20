using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repositorey
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User RefreshUserInfo(User user);
    }
}
