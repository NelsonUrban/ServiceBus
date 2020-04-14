using ExampleServiceBus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleServiceBus
{
    public class GetDummyDataForUser 
    {
        public List<UserDto> GetDataForUser()
        {
            UserDto user = new UserDto();
            List<UserDto> lstUsers = new List<UserDto>();
            for (int i = 1; i < 3; i++)
            {
                user = new UserDto();
                user.Id = i;
                user.Name = "Nelson" + i;

                lstUsers.Add(user);
            }

            return lstUsers;
        }


    }

  
}
