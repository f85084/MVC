﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineGame.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OnlineGameContext : DbContext
    {
        public OnlineGameContext()
            : base("name=OnlineGameContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gamer> Gamers { get; set; }
        public virtual DbSet<MultipleSelect> MultipleSelects { get; set; }
        public virtual DbSet<SingleSelect> SingleSelects { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    
        public virtual int spAddGamer(string name, string gender, string city, Nullable<System.DateTime> dateOfBirth, string emailAddress, Nullable<int> score, string profileUrl, Nullable<int> gameMoney, Nullable<int> teamId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(int));
    
            var profileUrlParameter = profileUrl != null ?
                new ObjectParameter("ProfileUrl", profileUrl) :
                new ObjectParameter("ProfileUrl", typeof(string));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddGamer", nameParameter, genderParameter, cityParameter, dateOfBirthParameter, emailAddressParameter, scoreParameter, profileUrlParameter, gameMoneyParameter, teamIdParameter);
        }
    
        public virtual int spDeleteGamer(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteGamer", idParameter);
        }
    
        public virtual ObjectResult<spGetGamers_Result> spGetGamers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetGamers_Result>("spGetGamers");
        }
    
        public virtual int spSaveGamer(Nullable<int> id, string name, string gender, string city, Nullable<System.DateTime> dateOfBirth, string emailAddress, Nullable<int> score, string profileUrl, Nullable<int> gameMoney, Nullable<int> teamId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(int));
    
            var profileUrlParameter = profileUrl != null ?
                new ObjectParameter("ProfileUrl", profileUrl) :
                new ObjectParameter("ProfileUrl", typeof(string));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSaveGamer", idParameter, nameParameter, genderParameter, cityParameter, dateOfBirthParameter, emailAddressParameter, scoreParameter, profileUrlParameter, gameMoneyParameter, teamIdParameter);
        }

        public System.Data.Entity.DbSet<OnlineGame.Web.Models.GamerA> GamerAs { get; set; }
    }
}
