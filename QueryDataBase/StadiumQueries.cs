using System.Diagnostics.CodeAnalysis;

namespace QueryDataBase
{
    [ExcludeFromCodeCoverage]
    public static class StadiumQueries
    {
        //    public static string AllBook => "SELECT * FROM [Book] (NOLOCK)";

        //    public static string BookId => "SELECT * FROM [Book] (NOLOCK) WHERE [BookId] = @ContactId";
        //    public static string InsertBookContact =>
        //    @"INSERT INTO [Contact] ([FirstName], [LastName], [Email], [PhoneNumber]) 
        //VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

        public static string UpdateStadiumIamge =>
            @"UPDATE [Contact] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Email] = @Email, 
				[PhoneNumber] = @PhoneNumber
            WHERE [ContactId] = @ContactId";

        //    public static string DeleteBook => "DELETE FROM [Contact] WHERE [ContactId] = @ContactId";
    }
}
