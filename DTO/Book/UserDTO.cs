namespace Book_Lending.DTO.Book;

    public class UserDTO
    {
        public long UserId { get; set; }
        public string? Name { get; set; }

        public string? MiddleName { get; set; }

        public string? Surname { get; set; }

        public DateTime? CreatedDate { get; set; }
    }



    public class UserUpdateDTO
    {
        public long UserId { get; set; }
        public string? Name { get; set; }

        public string? MiddleName { get; set; }

        public string? Surname { get; set; }
    }

