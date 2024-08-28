USE [SOCIAL_MEDIA]
GO

-- Insert 10 Users
INSERT INTO [dbo].[Users] ([Name], [Email], [Username], [Password])
VALUES
    ('John Doe', 'john.doe@example.com', 'john.doe', 'password123'),
    ('Jane Smith', 'jane.smith@example.com', 'jane.smith', 'password456'),
    ('Alice Johnson', 'alice.johnson@example.com', 'alice.johnson', 'password789'),
    ('Bob Brown', 'bob.brown@example.com', 'bob.brown', 'password012'),
    ('Carol White', 'carol.white@example.com', 'carol.white', 'password345'),
    ('David Green', 'david.green@example.com', 'david.green', 'password678'),
    ('Eve Black', 'eve.black@example.com', 'eve.black', 'password901'),
    ('Frank Blue', 'frank.blue@example.com', 'frank.blue', 'password234'),
    ('Grace Gray', 'grace.gray@example.com', 'grace.gray', 'password567'),
    ('Hannah Red', 'hannah.red@example.com', 'hannah.red', 'password890');
GO

-- Insert 20 Posts (2 posts per user)
INSERT INTO [dbo].[Post] ([Content], [UserId])
VALUES
    ('Post 1 by John Doe', 1),
    ('Post 2 by John Doe', 1),
    ('Post 1 by Jane Smith', 2),
    ('Post 2 by Jane Smith', 2),
    ('Post 1 by Alice Johnson', 3),
    ('Post 2 by Alice Johnson', 3),
    ('Post 1 by Bob Brown', 4),
    ('Post 2 by Bob Brown', 4),
    ('Post 1 by Carol White', 5),
    ('Post 2 by Carol White', 5),
    ('Post 1 by David Green', 6),
    ('Post 2 by David Green', 6),
    ('Post 1 by Eve Black', 7),
    ('Post 2 by Eve Black', 7),
    ('Post 1 by Frank Blue', 8),
    ('Post 2 by Frank Blue', 8),
    ('Post 1 by Grace Gray', 9),
    ('Post 2 by Grace Gray', 9),
    ('Post 1 by Hannah Red', 10),
    ('Post 2 by Hannah Red', 10);
GO

-- Insert 40 Likes (2 likes per post)
INSERT INTO [dbo].[Likes] ([PostId], [UserId])
VALUES
    -- Likes for Post 1 by John Doe
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5),
    (1, 6),
    -- Likes for Post 2 by John Doe
    (2, 2),
    (2, 3),
    (2, 4),
    (2, 5),
    (2, 6),
    -- Likes for Post 1 by Jane Smith
    (3, 1),
    (3, 4),
    (3, 5),
    (3, 6),
    (3, 7),
    -- Likes for Post 2 by Jane Smith
    (4, 1),
    (4, 4),
    (4, 5),
    (4, 6),
    (4, 7),
    -- Likes for Post 1 by Alice Johnson
    (5, 1),
    (5, 2),
    (5, 4),
    (5, 6),
    (5, 7),
    -- Likes for Post 2 by Alice Johnson
    (6, 1),
    (6, 2),
    (6, 4),
    (6, 6),
    (6, 7),
    -- Likes for Post 1 by Bob Brown
    (7, 1),
    (7, 2),
    (7, 3),
    (7, 4),
    (7, 5),
    -- Likes for Post 2 by Bob Brown
    (8, 1),
    (8, 2),
    (8, 3),
    (8, 4),
    (8, 5),
    -- Likes for Post 1 by Carol White
    (9, 2),
    (9, 3),
    (9, 4),
    (9, 5),
    (9, 6),
    -- Likes for Post 2 by Carol White
    (10, 2),
    (10, 3),
    (10, 4),
    (10, 5),
    (10, 6),
    -- Likes for Post 1 by David Green
    (11, 2),
    (11, 3),
    (11, 4),
    (11, 5),
    (11, 7),
    -- Likes for Post 2 by David Green
    (12, 2),
    (12, 3),
    (12, 4),
    (12, 5),
    (12, 7),
    -- Likes for Post 1 by Eve Black
    (13, 1),
    (13, 2),
    (13, 3),
    (13, 4),
    (13, 5),
    -- Likes for Post 2 by Eve Black
    (14, 1),
    (14, 2),
    (14, 3),
    (14, 4),
    (14, 5),
    -- Likes for Post 1 by Frank Blue
    (15, 1),
    (15, 2),
    (15, 3),
    (15, 4),
    (15, 6),
    -- Likes for Post 2 by Frank Blue
    (16, 1),
    (16, 2),
    (16, 3),
    (16, 4),
    (16, 6),
    -- Likes for Post 1 by Grace Gray
    (17, 1),
    (17, 2),
    (17, 3),
    (17, 4),
    (17, 5),
    -- Likes for Post 2 by Grace Gray
    (18, 1),
    (18, 2),
    (18, 3),
    (18, 4),
    (18, 5),
    -- Likes for Post 1 by Hannah Red
    (19, 2),
    (19, 3),
    (19, 4),
    (19, 5),
    (19, 6),
    -- Likes for Post 2 by Hannah Red
    (20, 2),
    (20, 3),
    (20, 4),
    (20, 5),
    (20, 6);
GO

-- Insert 50 Comments (5 comments per post)
INSERT INTO [dbo].[Comment] ([Content], [PostId], [UserId])
VALUES
    -- Comments for Post 1 by John Doe
    ('Nice post!', 1, 2),
    ('I agree!', 1, 3),
    ('Great content!', 1, 4),
    ('Thanks for sharing!', 1, 5),
    ('Awesome!', 1, 6),
    -- Comments for Post 2 by John Doe
    ('Interesting!', 2, 1),
    ('Very cool!', 2, 2),
    ('Well said!', 2, 3),
    ('Can’t wait to see more!', 2, 4),
    ('Love it!', 2, 5),
    -- Comments for Post 1 by Jane Smith
    ('Looks good!', 3, 1),
    ('Nice read!', 3, 2),
    ('I like this!', 3, 4),
    ('Informative!', 3, 5),
    ('Good job!', 3, 6),
    -- Comments for Post 2 by Jane Smith
    ('So true!', 4, 1),
    ('Very helpful!', 4, 2),
    ('Interesting perspective!', 4, 3),
    ('Great insights!', 4, 4),
    ('Well done!', 4, 5),
    -- Comments for Post 1 by Alice Johnson
    ('Very nice!', 5, 2),
    ('I enjoyed this!', 5, 3),
    ('Great read!', 5, 4),
    ('Well written!', 5, 5),
    ('Nice job!', 5, 6),
    -- Comments for Post 2 by Alice Johnson
    ('Amazing!', 6, 1),
    ('Fantastic!', 6, 2),
    ('Really good!', 6, 3),
    ('Superb!', 6, 4),
    ('Great post!', 6, 5),
    -- Comments for Post 1 by Bob Brown
    ('Nice!', 7, 1),
    ('Good post!', 7, 2),
    ('Enjoyed reading!', 7, 3),
    ('Interesting!', 7, 4),
    ('Very informative!', 7, 5),
    -- Comments for Post 2 by Bob Brown
    ('Well said!', 8, 1),
    ('Nice content!', 8, 2),
    ('Very engaging!', 8, 3),
    ('Excellent!', 8, 4),
    ('Great post!', 8, 5),
    -- Comments for Post 1 by Carol White
    ('Loved it!', 9, 1),
    ('Really enjoyed!', 9, 2),
    ('Well done!', 9, 3),
    ('Interesting read!', 9, 4),
    ('Great job!', 9, 5),
    -- Comments for Post 2 by Carol White
    ('Fantastic!', 10, 1),
    ('Great content!', 10, 2),
    ('Well presented!', 10, 3),
    ('Very informative!', 10, 4),
    ('Nice work!', 10, 5),
    -- Comments for Post 1 by David Green
    ('Good post!', 11, 1),
    ('Nice content!', 11, 2),
    ('Very interesting!', 11, 3),
    ('Great read!', 11, 4),
    ('I liked it!', 11, 5),
    -- Comments for Post 2 by David Green
    ('Well done!', 12, 1),
    ('Great insights!', 12, 2),
    ('Very informative!', 12, 3),
    ('Nice work!', 12, 4),
    ('Interesting!', 12, 5),
    -- Comments for Post 1 by Eve Black
    ('Nice job!', 13, 1),
    ('Good read!', 13, 2),
    ('Interesting!', 13, 3),
    ('Well written!', 13, 4),
    ('Loved it!', 13, 5),
    -- Comments for Post 2 by Eve Black
    ('Great job!', 14, 1),
    ('Very interesting!', 14, 2),
    ('Well done!', 14, 3),
    ('Good content!', 14, 4),
    ('Excellent!', 14, 5),
    -- Comments for Post 1 by Frank Blue
    ('Nice post!', 15, 1),
    ('Great content!', 15, 2),
    ('Well presented!', 15, 3),
    ('Very informative!', 15, 4),
    ('Good job!', 15, 5),
    -- Comments for Post 2 by Frank Blue
    ('Excellent read!', 16, 1),
    ('Great post!', 16, 2),
    ('Interesting!', 16, 3),
    ('Nice work!', 16, 4),
    ('Good content!', 16, 5),
    -- Comments for Post 1 by Grace Gray
    ('Well done!', 17, 1),
    ('Great job!', 17, 2),
    ('Nice content!', 17, 3),
    ('Interesting read!', 17, 4),
    ('Loved it!', 17, 5),
    -- Comments for Post 2 by Grace Gray
    ('Fantastic!', 18, 1),
    ('Very good!', 18, 2),
    ('Good read!', 18, 3),
    ('Nice work!', 18, 4),
    ('Great content!', 18, 5),
    -- Comments for Post 1 by Hannah Red
    ('Nice post!', 19, 1),
    ('Well done!', 19, 2),
    ('Great read!', 19, 3),
    ('Very interesting!', 19, 4),
    ('Good job!', 19, 5),
    -- Comments for Post 2 by Hannah Red
    ('Loved it!', 20, 1),
    ('Good content!', 20, 2),
    ('Great job!', 20, 3),
    ('Interesting!', 20, 4),
    ('Nice post!', 20, 5);
GO
