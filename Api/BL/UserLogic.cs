using DAL.Functions;
using DAL.Interfaces;
using AutoMapper;
using BL.Models;
using DAL.Entities;


namespace BL
{
    public class UserLogic
    {
        private IUser _user = new UserFunctions();
        private Mapper _mapper;

        public UserLogic()
        {
            var _configMap = new MapperConfiguration(c => c.CreateMap<User, UserModel>().ReverseMap());
            _mapper = new Mapper(_configMap);
        }

        public async Task<List<UserModel>> GetAll()
        {
            List<UserModel> users = new List<UserModel>();

            try
            {
                var result = await _user.GetAll();
                users = _mapper.Map<List<User>, List<UserModel>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }

            return users;
        }

        public async Task<bool> Add(UserModel userModel)
        {
            bool isAdded = false;
            try
            {
                User user = _mapper.Map<UserModel, User>(userModel);
                var result = await _user.Add(user);
                isAdded = result.Id > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw;
            }

            return isAdded;
        }

        public async Task<bool> Update(UserModel userModel)
        {
            bool isUpdated = false;

            try
            {
                User user = _mapper.Map<UserModel, User>(userModel);
                var res = await _user.Update(user);
                isUpdated = res != null ? true : false;
            }
            catch (Exception ex)
            {

                throw;
            }

            return isUpdated;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            try
            {
                _user.Delete(id).Wait();
                isDeleted = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return isDeleted;
        }
    }
}