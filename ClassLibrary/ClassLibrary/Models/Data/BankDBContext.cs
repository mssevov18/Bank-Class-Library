using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class BankDBContext : DbContext
    {
        public BankDBContext()
        {
        }

        public BankDBContext(DbContextOptions<BankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BankWorker> BankWorkers { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardReader> CardReaders { get; set; }
        public virtual DbSet<CardReaderAccountConnection> CardReaderAccountConnections { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionAccountsConnection> TransactionAccountsConnections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BankDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Iban, "IX_Account")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "IX_Account_1")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "IX_Account_2")
                    .IsUnique();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Account_Person");
            });

            modelBuilder.Entity<BankWorker>(entity =>
            {
                entity.ToTable("BankWorker");

                entity.HasIndex(e => e.PersonId, "IX_BankWorker")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "IX_BankWorker_1")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.BankWorker)
                    .HasForeignKey<BankWorker>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankWorker_Person");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.HasIndex(e => e.Number, "IX_Card")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiresOn).HasColumnType("date");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PIN");

                entity.HasOne(d => d.Holder)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.HolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Account");
            });

            modelBuilder.Entity<CardReader>(entity =>
            {
                entity.ToTable("CardReader");
            });

            modelBuilder.Entity<CardReaderAccountConnection>(entity =>
            {
                entity.ToTable("CardReaderAccountConnection");

                entity.HasIndex(e => e.RecieverId, "IX_CardReaderAccountConnection")
                    .IsUnique();

                entity.HasIndex(e => e.CardReaderId, "IX_CardReaderAccountConnection_1")
                    .IsUnique();

                entity.HasOne(d => d.CardReader)
                    .WithOne(p => p.CardReaderAccountConnection)
                    .HasForeignKey<CardReaderAccountConnection>(d => d.CardReaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardReaderAccountConnection_CardReader");

                entity.HasOne(d => d.Reciever)
                    .WithOne(p => p.CardReaderAccountConnection)
                    .HasForeignKey<CardReaderAccountConnection>(d => d.RecieverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardReaderAccountConnection_Account");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.Egn, "IX_Person")
                    .IsUnique();

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Egn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EGN")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Residence)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TransactionAccountsConnection>(entity =>
            {
                entity.ToTable("TransactionAccountsConnection");

                entity.HasIndex(e => new { e.TransactionId, e.SenderId, e.RecieverId }, "IX_TransactionAccountsConnection")
                    .IsUnique();

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.TransactionAccountsConnectionRecievers)
                    .HasForeignKey(d => d.RecieverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Account1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TransactionAccountsConnectionSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Account");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionAccountsConnections)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Transaction");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
