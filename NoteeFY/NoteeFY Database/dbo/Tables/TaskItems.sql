CREATE TABLE [dbo].[TaskItems] (
    [TaskItemID] INT            IDENTITY (1, 1) NOT NULL,
    [Text]       NVARCHAR (MAX) NULL,
    [IsDone]     BIT            NOT NULL,
    [NoteID]     INT            NOT NULL,
    CONSTRAINT [PK_TaskItems] PRIMARY KEY CLUSTERED ([TaskItemID] ASC),
    CONSTRAINT [FK_TaskItems_Notes] FOREIGN KEY ([NoteID]) REFERENCES [dbo].[Notes] ([NoteID]) ON DELETE CASCADE ON UPDATE CASCADE
);

