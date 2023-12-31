USE [test]
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [money] NOT NULL,
	[Balance] [money] NOT NULL,
	[Version] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [money] NOT NULL,
	[PaymentAmount] [money] NOT NULL,
	[Version] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[IncomeId] [int] NOT NULL,
	[PaymentAmount] [money] NOT NULL,
	[Version] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [PaymentAmount]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([IncomeId])
REFERENCES [dbo].[Incomes] ([Id])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Incomes]  WITH CHECK ADD CHECK  (([Amount]>(0)))
GO
ALTER TABLE [dbo].[Incomes]  WITH CHECK ADD  CONSTRAINT [CK_Incomes_Balance] CHECK  (([Balance]>=(0) AND [Balance]<=[Amount]))
GO
ALTER TABLE [dbo].[Incomes] CHECK CONSTRAINT [CK_Incomes_Balance]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CHECK  (([Amount]>(0)))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [CK_Orders_PaymentAmount] CHECK  (([PaymentAmount]>=(0) AND [PaymentAmount]<=[Amount]))
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [CK_Orders_PaymentAmount]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD CHECK  (([PaymentAmount]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIncome]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIncome]
    @Id INT,
    @IncomeVersion BINARY(8)
AS
BEGIN
SET NOCOUNT ON;
  
DECLARE @CurrentIncomeVersion BINARY(8);

SELECT @CurrentIncomeVersion = Version FROM Incomes WHERE Id = @Id;

IF @CurrentIncomeVersion = @IncomeVersion 
BEGIN
    DELETE FROM Incomes WHERE Id = @Id;

    RETURN 0;
END
ELSE
BEGIN 
    RETURN -1; 
 END 

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteOrder]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteOrder]
    @Id INT,
    @OrderVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentOrderVersion BINARY(8);

    SELECT @CurrentOrderVersion = Version FROM Orders WHERE Id = @Id;

    IF @CurrentOrderVersion = @OrderVersion 
    BEGIN
        DELETE FROM Orders WHERE Id = @Id;

        RETURN 0;
    END
    ELSE
    BEGIN 
        RETURN -1; 
     END 

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePayment]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePayment]
    @Id INT,
    @PaymentVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentPaymentVersion BINARY(8);

    SELECT @CurrentPaymentVersion = Version FROM Payments WHERE Id = @Id;

    IF @CurrentPaymentVersion = @PaymentVersion 
    BEGIN
        DELETE FROM Payments WHERE Id = @Id;

        RETURN 0;
    END
    ELSE
    BEGIN 
        RETURN -1; 
     END 

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIncomes]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetIncomes]
AS
BEGIN
    SELECT Id, Date, Amount, Balance, Version FROM Incomes;

    RETURN;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrders]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetOrders]
AS
BEGIN
    SELECT Id, Date, Amount, PaymentAmount, Version FROM Orders;

    RETURN;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPayments]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPayments]
AS
BEGIN
    SELECT Id, OrderId, IncomeId, PaymentAmount, Version FROM Payments;

    RETURN;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIncome]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertIncome]
    @Date DATE,
    @Amount MONEY,
    @Balance MONEY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Incomes (Date, Amount, Balance) VALUES (@Date, @Amount, @Balance);

    RETURN 0;

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrder]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertOrder]
    @Date DATE,
    @Amount MONEY,
    @PaymentAmount MONEY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Orders (Date, Amount, PaymentAmount) VALUES (@Date, @Amount, @PaymentAmount);

    RETURN 0;

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPayment]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertPayment]
    @OrderId INT,
    @IncomeId INT,
    @PaymentAmount MONEY,
    @OrderVersion BINARY(8),
    @IncomeVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentOrderVersion BINARY(8);
    DECLARE @CurrentIncomeVersion BINARY(8);

    SELECT @CurrentOrderVersion = Version FROM Orders WHERE Id = @OrderId;
    SELECT @CurrentIncomeVersion = Version FROM Incomes WHERE Id = @IncomeId;

    IF @CurrentOrderVersion = @OrderVersion AND @CurrentIncomeVersion = @IncomeVersion
    BEGIN
        INSERT INTO Payments (OrderId, IncomeId, PaymentAmount) VALUES (@OrderId, @IncomeId, @PaymentAmount);

        RETURN 0;
    END
    ELSE
    BEGIN
        RETURN -1;
    END

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateIncome]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateIncome]
    @Id INT,
    @Date DATE,
    @Amount MONEY,
    @Balance MONEY,
    @IncomeVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentIncomeVersion BINARY(8);

    SELECT @CurrentIncomeVersion = Version FROM Incomes WHERE Id = @Id;

    IF @CurrentIncomeVersion = @IncomeVersion 
    BEGIN
        UPDATE Incomes SET Date = @Date, Amount = @Amount, Balance = @Balance WHERE Id = @Id;

        RETURN 0;
    END
    ELSE
    BEGIN 
        RETURN -1; 
     END 

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateOrder]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateOrder]
    @Id INT,
    @Date DATE,
    @Amount MONEY,
    @PaymentAmount MONEY,
    @OrderVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentOrderVersion BINARY(8);

    SELECT @CurrentOrderVersion = Version FROM Orders WHERE Id = @Id;

    IF @CurrentOrderVersion = @OrderVersion 
    BEGIN
        UPDATE Orders SET Date = @Date, Amount = @Amount, PaymentAmount = @PaymentAmount WHERE Id = @Id;

        RETURN 0;
    END
    ELSE
    BEGIN 
        RETURN -1; 
     END 

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePayment]    Script Date: 24.07.2023 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePayment]
    @Id INT,
    @OrderId INT,
    @IncomeId INT,
    @PaymentAmount MONEY,
    @PaymentVersion BINARY(8),
    @OrderVersion BINARY(8),
    @IncomeVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentPaymentVersion BINARY(8);
    DECLARE @CurrentOrderVersion BINARY(8);
    DECLARE @CurrentIncomeVersion BINARY(8);

    SELECT @CurrentPaymentVersion = Version FROM Payments WHERE Id = @Id;
    SELECT @CurrentOrderVersion = Version FROM Orders WHERE Id = @OrderId;
    SELECT @CurrentIncomeVersion = Version FROM Incomes WHERE Id = @IncomeId;

    IF @CurrentPaymentVersion = @PaymentVersion AND @CurrentOrderVersion = @OrderVersion AND @CurrentIncomeVersion = @IncomeVersion
    BEGIN
        UPDATE Payments SET OrderId = @OrderId, IncomeId = @IncomeId, PaymentAmount = @PaymentAmount WHERE Id = @Id;

        RETURN 0;
    END
    ELSE
    BEGIN
        RETURN -1;
    END

END;
GO
