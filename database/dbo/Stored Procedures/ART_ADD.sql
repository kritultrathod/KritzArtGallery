CREATE PROCEDURE ART_ADD @ID INT OUTPUT
	,@Name VARCHAR(100)
	,@Artist VARCHAR(50)
	,@DimInch VARCHAR(15)
	,@DimCm VARCHAR(15)
	,@Description VARCHAR(500)
	,@Price FLOAT
	,@Private BIT
	,@Available BIT
	,@SendAFriend BIT
	,@ImageSmall VARCHAR(200)
	,@ImageLarge VARCHAR(200)
AS
SET NOCOUNT ON

--	DECLARE @CountRec int
--		SELECT @CountRec = COUNT(*) FROM SchoolMaster
--		WHERE SchoolName = @SchoolName
--	IF @CountRec = 0
BEGIN
	INSERT INTO ArtDetails (
		Name
		,Artist
		,DimInch
		,DimCm
		,Description
		,Price
		,Private
		,Available
		,SendAFriend
		,ImageSmall
		,ImageLarge
		,LastModifiedOn
		)
	VALUES (
		@Name
		,@Artist
		,@DimInch
		,@DimCm
		,@Description
		,@Price
		,@Private
		,@Available
		,@SendAFriend
		,@ImageSmall
		,@ImageLarge
		,GETDATE()
		)

	SELECT @ID = @@IDENTITY

	PRINT 0

	RETURN 0
END

--	ELSE
--	BEGIN
--		SELECT  @ID =  0 
--		PRINT 1
--		RETURN 1
--	END
SET NOCOUNT OFF
