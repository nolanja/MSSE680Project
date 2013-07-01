USE [DBIntegration];

DECLARE @CreatedDateTime DATETIME = GETDATE(),
		@CreatedBy NVARCHAR(50) = 'dbIntegration Setup Script'

MERGE [Organization] AS T USING
(
	SELECT 'BNZL' AS [OrganizationCode], 'Bunzel Distribution' AS [OrganizationName], '555-234-1234' AS [PhoneNumber], '555-234-1235' AS [FaxNumber],
	'BNZL' AS [ParentOrganizationCode], 'Standard' AS [Theme], 'Red' AS [Skin], 'True' AS [Active], 'False'AS [DELETED]
	UNION ALL
	SELECT 'CPC' AS [OrganizationCode], 'Constant Product Center' AS [OrganizationName], '555-243-1234' AS [PhoneNumber], '555-243-1235' AS [FaxNumber],
	'CPC' AS [ParentOrganizationCode], 'Custom' AS [Theme], 'Green' AS [Skin], 'True' AS [Active], 'False' AS [DELETED]
) AS S ON T.OrganizationCode = S.OrganizationCode

WHEN NOT MATCHED BY TARGET THEN
	INSERT(OrganizationCode,OrganizationName,PhoneNumber, FaxNumber, ParentOrganizationCode, Theme, Skin, Active, DELETED, CreatedDateTime, CreatedBy)
	VALUES(S.OrganizationCode,S.OrganizationName,S.PhoneNumber, S.FaxNumber, S.ParentOrganizationCode, S.Theme, S.Skin, S.Active, S.DELETED, @CreatedDateTime,@CreatedBy)
WHEN MATCHED THEN
	UPDATE
	SET		T.OrganizationCode = S.OrganizationCode,
			T.OrganizationName = S.OrganizationName,
			T.PhoneNumber = S.PhoneNumber,
			T.FaxNumber = S.FaxNumber,
			T.ParentOrganizationCode = S.ParentOrganizationCode,
			T.Theme = S.Theme,
			T.Skin = S.Skin,
			T.Active = S.Active,
			T.DELETED = S.DELETED,
			T.ModifiedDateTime = @CreatedDateTime,
			T.ModifiedBy = @CreatedBy
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
;
		
MERGE [Rules] AS T USING
(
	SELECT 6 AS [ValueTypeId], 'MinimumOrderAmount' AS [RuleName], 'Minimum Amount of Order' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MinimumOrderPreventFlag' AS [RuleName], 'Error If Minimum Order Not Met' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MinimumOrderEnable' AS [RuleName], 'Turn Minimum Order Validation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'MaximumLineItemQuantity' AS [RuleName], 'Max Quantity Per Line Item' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'MaximumQtyCharacters' AS [RuleName], 'Maximum Characters for Qty Field' AS [Rule Description]
		UNION ALL
	SELECT 6 AS [ValueTypeId], 'MaximumOrderAmount' AS [RuleName], 'Maximum Amount of Order' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MaximumOrderAmountPreventFlag' AS [RuleName], 'Error if Maximum Order Exceeded' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MaximumOrderAmountEnable' AS [RuleName], 'Turn Maximum Order Validation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'MinimumCaseQuantity' AS [RuleName], 'Minimum Cases Required for Order' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MinimumCaseQuantityPreventFlag' AS [RuleName], 'Error if Minimum Cases Are Not Ordered' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'MinimumCaseQuantityEnable' AS [RuleName], 'Turn Minimum Case Quantity Validation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'RepeatingDigitPreventFlag' AS [RuleName], 'Error if Repeating Digits are Present' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'RepeatingDigitEnable' AS [RuleName], 'Turn Repeating Digit Validation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'ExcessQuantity' AS [RuleName], 'Excessive Item Quanity' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'ExcessQuantityPreventFlag' AS [RuleName], 'Error if Excess Quantity is Exceeded' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'ExcessQuantityEnable' AS [RuleName], 'Turn Excess Quantity Validation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'AllowChangeShippingAddress' AS [RuleName], 'Allow One Time Shipping Address' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'ShowSpecialInstructionsFlag' AS [RuleName], 'Display Special Instructions On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'SpecialInstructionsCharLimit' AS [RuleName], 'Special Instructions Character Limit' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'SubstitutionEnable' AS [RuleName], 'Allow Substitutions' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'SubstitutionOverrideEnable' AS [RuleName], 'Override Substitutions Enabled' AS [RuleDescription]
		UNION ALL
	SELECT 8 AS [ValueTypeId], 'PONumberSetting' AS [RuleName], 'Purchase Order Settings' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'MaximumPurchaseOrderCodeLength' AS [RuleName], 'Purchase Order Code Character Limit' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'ProductListAuditExpireInDays' AS [RuleName], 'Days to Display Product List Changes' AS [RuleDescription]
		UNION ALL
	SELECT 9 AS [ValueTypeId], 'ProductAuditExpireInDays' AS [RuleName], 'Days to Display Product Changes' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'ReceiveOrderFlag' AS [RuleName], 'Receive Orders On/Off'  AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'SendConfirmationFlag' AS [RuleName], 'Send Confirmation On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'SendInvoiceFlag' AS [RuleName], 'Send Invoice On/Off' AS [RuleDescription]
		UNION ALL
	SELECT 1 AS [ValueTypeId], 'AllowSeparateInvoices' AS [RuleName], 'Allow Separate Invoices for Orders' AS [RuleDescription]
		UNION ALL
	SELECT 8 AS [ValueTypeId], 'PricePrecision' AS [RuleName], 'Decimal Precision for Case/Each Quantity Items' AS [RuleDescription]
		UNION ALL
	SELECT 8 AS [ValueTypeId], 'PriceWeightPrecision' AS [RuleName], 'Decimal Precision for CatchWeight Items' AS [RuleDescription]
		UNION ALL
	SELECT 8 AS [ValueTypeId], 'POSellRuleType' AS [RuleName], 'Flag Indicating DC Code Should be Concatenated with Org Code (Org+DC) - Exchange' AS [RuleDescription]
) AS S ON T.ValueTypeId = S.ValueTypeId
WHEN NOT MATCHED BY TARGET THEN
	INSERT(ValueTypeId,RuleName,RuleDescription,CreatedDateTime,CreatedBy)
	VALUES(S.ValueTypeId,S.RuleName,S.RuleDescription,@CreatedDateTime,@CreatedBy)
WHEN MATCHED THEN
	UPDATE
	SET		T.ValueTypeId = S.ValueTypeId,
			T.RuleName = S.RuleName,
			T.RuleDescription = S.RuleDescription,
			T.ModifiedDateTime = @CreatedDateTime,
			T.ModifiedBy = @CreatedBy
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
;

MERGE [SiteType] AS T USING
(
	SELECT  'DistributionCenter' AS [SiteTypeName]
		UNION ALL
	SELECT 'CustomerLocation' AS [SiteTypeName]
		UNION ALL
	SELECT  'Corporate Office' AS [SiteTypeName]
) AS S ON T.SiteTypeName = S.SiteTypeName
WHEN NOT MATCHED BY TARGET THEN
	INSERT(SiteTypeName,CreatedDateTime,CreatedBy)
	VALUES(S.SiteTypeName,@CreatedDateTime,@CreatedBy)
WHEN MATCHED THEN
	UPDATE
	SET		T.SiteTypeName = S.SiteTypeName,
			T.ModifiedDateTime = @CreatedDateTime,
			T.ModifiedBy = @CreatedBy
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
;

MERGE [UserType] AS T USING
(
	Select 'Admin' AS [UserTypeName]
		UNION ALL 
	SELECT 'User' AS [UserTypeName]
		UNION ALL
	SELECT 'Consumer' AS [UserTypeName]
) AS S ON T.UserTypeName = S.UserTypeName
WHEN NOT MATCHED BY TARGET THEN
	INSERT(UserTypeName,CreatedDateTime,CreatedBy)
	VALUES(S.UserTypeName,@CreatedDateTime,@CreatedBy)
WHEN MATCHED THEN
	UPDATE
	SET		T.UserTypeName = S.UserTypeName,
			T.ModifiedDateTime = @CreatedDateTime,
			T.ModifiedBy = @CreatedBy
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
;
