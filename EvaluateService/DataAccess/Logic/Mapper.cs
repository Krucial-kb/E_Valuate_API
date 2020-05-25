using E_ValuateDataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_ValuateDataAccess.Logic
{
    public class Mapper
    {

        ///-------------------------------------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------
        ///--------------------------------------------Data Models------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------
        public static E_ValuateDataAccess.DataModels.Users MapUsers(E_valuateDomain.DomainModels.Users users)
        {
            return new E_ValuateDataAccess.DataModels.Users
            {
                UserId = users.UserID,
                FullName = users.fullName,
                Username = users.userName,
                Telephone = users.Telephone,
                Email = users.Email,
                Password = users.Password,
                Dob = users.DOB,
                Platform = users.Platform
            };
        }

        public static E_ValuateDataAccess.DataModels.Address MapAddress(E_valuateDomain.DomainModels.Address address)
        {
            return new E_ValuateDataAccess.DataModels.Address
            {
                AddressId = address.AddressID,
                Street = address.Street,
                City = address.City,
                Zip = address.Zip,
                State = address.State,
                Country = address.Country
            };
        }
        public static E_ValuateDataAccess.DataModels.PostsData MapPostsData(E_valuateDomain.DomainModels.PostsData postsData)
        {
            return new E_ValuateDataAccess.DataModels.PostsData
            {

            };
        }

        public static E_ValuateDataAccess.DataModels.PostsDetails MapPostsDetails(E_valuateDomain.DomainModels.PostsDetails postsDetails)
        {
            return new E_ValuateDataAccess.DataModels.PostsDetails
            {

            };
        }

        public static E_ValuateDataAccess.DataModels.FriendData MapFriendsData(E_valuateDomain.DomainModels.FriendData friendsData)
        {
            return new E_ValuateDataAccess.DataModels.FriendData
            {
                FriendId = friendsData.FriendID,

            };
        }

        public static E_ValuateDataAccess.DataModels.FriendsDetails MapFriendsDetails(E_valuateDomain.DomainModels.FriendsDetails friendsDetails)
        {
            return new E_ValuateDataAccess.DataModels.FriendsDetails
            {

            };
        }

        public static E_ValuateDataAccess.DataModels.PictureData MapPicture(E_valuateDomain.DomainModels.PictureData picture)
        {
            return new E_ValuateDataAccess.DataModels.PictureData
            {
                PictureId = picture.PictureID,
                ImgName = picture.imageName,
                ImgSource = picture.imageSource,
                ImgDate = picture.imageDate
            };
        }


        ///-------------------------------------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------
        ///--------------------------------------------Domain Models----------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------

        public static E_valuateDomain.DomainModels.Users MapUsers(E_ValuateDataAccess.DataModels.Users users)
        {
            return new E_valuateDomain.DomainModels.Users
            {
                UserID = users.UserId,
                fullName = users.FullName,
                userName = users.Username,
                ProfPicID = users.ProfilePictureNavigation?.ImgSource,
                Street = users.AddressNavigation?.Street,
                City = users.AddressNavigation?.City,
                State = users.AddressNavigation?.State,
                Zip = users.AddressNavigation.Zip,
                Country = users.AddressNavigation?.Country,
                Telephone = users.Telephone,
                Email = users.Email,
                Password = users.Password,
                DOB = users.Dob,
                Platform = users.Platform,
                ListFriendsDetails = users.FriendsDetails.Select(MapFriendsDetails).ToList(),
                listFriendsData = users.FriendData.Select(MapFriendsData).ToList(),
                listPosDetails = users.PostsDetails.Select(MapPostsDetails).ToList()

            };
        }

        public static E_valuateDomain.DomainModels.Address MapAddress(E_ValuateDataAccess.DataModels.Address address)
        {
            return new E_valuateDomain.DomainModels.Address
            {
                AddressID = address.AddressId,
                Street = address.Street,
                City = address.City,
                State = address.State,
                Zip = address.Zip,
                Country = address.Country
            };
        }

        public static E_valuateDomain.DomainModels.PostsData MapPostsData(E_ValuateDataAccess.DataModels.PostsData postsData)
        {
            return new E_valuateDomain.DomainModels.PostsData
            {
                PostID = postsData.PostId,
                Title = postsData.Title,
                Media = postsData.Media,
                Comment = postsData.Comment
            };
        }
        public static E_valuateDomain.DomainModels.PostsDetails MapPostsDetails(E_ValuateDataAccess.DataModels.PostsDetails postsDetails)
        {
            return new E_valuateDomain.DomainModels.PostsDetails
            {
                DetailsID = postsDetails.DetailsId,
                PostID = postsDetails.PostId,
                UserID = postsDetails.UserId,
                Quantity = postsDetails.Quantity,
                PostDate = postsDetails.PostDate
            };
        }

        public static E_valuateDomain.DomainModels.FriendData MapFriendsData(E_ValuateDataAccess.DataModels.FriendData friendsData)
        {
            return new E_valuateDomain.DomainModels.FriendData
            {
                FriendID = friendsData.FriendId,

            };
        }

        public static E_valuateDomain.DomainModels.FriendsDetails MapFriendsDetails(E_ValuateDataAccess.DataModels.FriendsDetails friendsDetails)
        {
            return new E_valuateDomain.DomainModels.FriendsDetails
            {
                DetailsID = friendsDetails.DetailsId,
                UserID = friendsDetails.UserId,
                FriendID = friendsDetails.FriendId,
                Quantity = friendsDetails.Quantity,
                DateAdded = friendsDetails.DateAdded
            };
        }

        public static E_valuateDomain.DomainModels.PictureData MapPicture(E_ValuateDataAccess.DataModels.PictureData picture)
        {
            return new E_valuateDomain.DomainModels.PictureData
            {
                PictureID = picture.PictureId,
                imageName = picture.ImgName,
                imageSource = picture.ImgSource,
                imageDate = picture.ImgDate
            };
        }
    }
}
