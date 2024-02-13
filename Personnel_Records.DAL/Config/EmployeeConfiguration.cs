﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personnel_Records.BLL.Models;

namespace Personnel_Records.DAL.Config;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
        builder.ToTable("Employees", "Personnel_Records");

        // Set column mappings
        builder.Property(e => e.Payroll_Number).HasColumnName("Payroll_Number");
        builder.Property(e => e.Forenames).HasColumnName("Forenames");
        builder.Property(e => e.Surname).HasColumnName("Surname");
        builder.Property(e => e.Date_of_Birth).HasColumnName("Date_of_Birth");
        builder.Property(e => e.Telephone).HasColumnName("Telephone");
        builder.Property(e => e.Mobile).HasColumnName("Mobile");
        builder.Property(e => e.Address).HasColumnName("Address");
        builder.Property(e => e.Address_2).HasColumnName("Address_2");
        builder.Property(e => e.Postcode).HasColumnName("Postcode");
        builder.Property(e => e.Email_Home).HasColumnName("EMail_Home");
        builder.Property(e => e.Start_Date).HasColumnName("Start_Date");

        // Set maximum lengths for string properties
        builder.Property(e => e.Payroll_Number).HasMaxLength(50);
        builder.Property(e => e.Forenames).HasMaxLength(100);
        builder.Property(e => e.Surname).HasMaxLength(100);
        builder.Property(e => e.Telephone).HasMaxLength(20);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.Address).HasMaxLength(255);
        builder.Property(e => e.Address_2).HasMaxLength(255);
        builder.Property(e => e.Postcode).HasMaxLength(20);
        builder.Property(e => e.Email_Home).HasMaxLength(100);

        // Set primary key
        builder.HasKey(e => e.Payroll_Number);
	}
}
