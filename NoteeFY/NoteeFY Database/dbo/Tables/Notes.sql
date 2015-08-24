CREATE TABLE [dbo].[Notes] (
    [NoteID]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (MAX) NULL,
    [Text]             NVARCHAR (MAX) NULL,
    [Type]             INT            NOT NULL,
    [ModificationDate] DATETIME       NOT NULL,
    [UserID]           NVARCHAR (50)  NOT NULL,
    [Color]            NVARCHAR (10)  NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteID] ASC),
    CONSTRAINT [FK_Notes_Users1] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
);



