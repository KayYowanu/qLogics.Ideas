/*  
Create qLogicsIdeas table
*/

CREATE TABLE [dbo].[qLogicsIdeas](
	[IdeasId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_qLogicsIdeas] PRIMARY KEY CLUSTERED 
  (
	[IdeasId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[qLogicsIdeas] WITH CHECK ADD CONSTRAINT [FK_qLogicsIdeas_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO