using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardDbContext : IdentityDbContext<IdentityUser>
    {
        private IdentityUser TestUser { get; set; } = null!;

        private Board OpenBoard { get; set; } = null!;

        private Board InProgressBoard { get; set; } = null!;

        private Board DoneBoard { get; set; } = null!;


        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
            //Database.Migrate();
        }


        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<Board> Boards { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUser();
            builder
                .Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoard();
            builder
                .Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);


            builder
                .Entity<Task>()
                .HasData(GenerateTask());

            base.OnModelCreating(builder);
        }

        private void SeedUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "123456");
        }


        private void SeedBoard()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }


        private Task[] GenerateTask()
        {
            ICollection<Task> tasks = new HashSet<Task>();
            Task currTask;

            currTask = new Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreateOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            };
            tasks.Add(currTask);

            currTask = new Task()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreateOn = DateTime.Now.AddMonths(-5),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            };
            tasks.Add(currTask);

            currTask = new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreateOn = DateTime.Now.AddMonths(-2),
                OwnerId = TestUser.Id,
                BoardId = InProgressBoard.Id
            };
            tasks.Add(currTask);

            currTask = new Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreateOn = DateTime.Now.AddYears(-1),
                OwnerId = TestUser.Id,
                BoardId = DoneBoard.Id
            };
            tasks.Add(currTask);

            return tasks.ToArray();
        }
    }
}