CREATE PROCEDURE ART_UPD @ID INT
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
	UPDATE ArtDetails
	SET Name = @Name
		,Artist = @Artist
		,DimInch = @DimInch
		,DimCm = @DimCm
		,Description = @Description
		,Price = @Price
		,Private = @Private
		,Available = @Available
		,SendAFriend = @SendAFriend
		,ImageSmall = @ImageSmall
		,ImageLarge = @ImageLarge
		,LastModifiedOn = GETDATE()
	WHERE ID = @ID

	RETURN 0
END

--	ELSE
--	BEGIN
--		SELECT  @ID =  0 
--		PRINT 1
--		RETURN 1
--	END
SET NOCOUNT OFF
