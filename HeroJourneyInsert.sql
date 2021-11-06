Create database HeroJourney

use HeroJourney

Insert into Levels(Lvl,MinimumExperience,MaximumExperience)
values
(1,100,199),
(2,200,299),
(3,300,399),
(4,400,499),
(5,500,699),
(6,700,899),
(7,900,1099),
(8,1100,1399),
(9,1400,1799),
(10,1800,1999),
(11,2000,2599),
(12,2600,2999),
(13,3000,3399),
(14,3400,3799),
(15,3800,4099),
(16,4100,4499),
(17,4500,4999),
(18,5000,20000)


insert into Classes([Name],Health,Attack,Defence,ImageUrl)
values
('Paladin',100,100,80,'paladinarena.png'),
('Wizard',100,70,100,'wizardarena.png'),
('Druid',100,80,80,'druidarena.png'),
('Viking',100,110,100,'arenaviking.png')


insert into EnemyClasses([Name],BonusAttack,BonusDefense,BonusHealth)
values
('Dragon',10,10,20),
('Water',10,20,20),
('Big',20,20,20),
('Evil',30,10,20),
('Red',10,10,20),
('Fire',20,10,20),
('White',10,10,20),
('Yellow',5,5,20),
('Sea',5,10,20),
('El',5,5,20),
('Hook',5,5,20),
('Cyber',10,5,20),
('Flying',10,20,20),
('Dark',30,10,20),
('King',30,30,20),
('Blue Eyes',20,20,20),
('Red Eyes',20,20,20),
('Boss',30,30,20),
('Machine',20,20,20)

insert into EnemyTypes([Name],[Level],Attack,Defense,Health)
values
('Dinosaur',1,50,50,60),
('Kraken',1,50,50,60),
('Witch',1,50,50,56),
('Basilisk',1,50,50,60),
('Griffin',1,50,50,50),
('Skeleton',1,40,40,30),
('Salamander',1,50,40,20),
('Turtle',1,10,15,30),
('Monkey',1,20,20,30),
('Tiger',1,35,35,30),
('Mummy',1,35,35,20),
('Phoenix',1,20,15,50),
('Sphinx',1,30,30,40),
('Monk',1,30,10,30),
('Chimera',1,30,30,30),
('Gorgon',1,20,20,30),
('Medusa',1,20,20,30),
('Python',1,30,30,30),
('Ghoul',1,40,40,30),
('Leviathan',1,50,50,30),
('Lucifer',1,40,40,40),
('Big Foot',1,40,40,30),
('Gremlin',1,30,30,20),
('Mermaid',1,20,20,20),
('Baba Yaga',1,30,20,20),
('Dracula',1,30,15,30),
('Lizard',1,20,20,20),
('Scorpion',1,20,20,20),
('Orc',1,20,20,20),
('Kraken',1,30,30,30),
('Hydra',1,30,30,30),
('Lord',1,30,30,50),
('Goblins',1,30,30,20),
('Trolls',1,20,20,20),
('Bear',1,40,40,30),
('Rat',1,20,20,10),
('Hyena',1,20,20,20),
('Vampire',1,20,20,30)

Insert into Items([Name],Price,[Description],IsSpecial,HealthPoints,DefensePoints,AttackPoints,ClassId)
values
('Health Potion',120,'Health +100',0,100,0,0,NULL),
('Defense',100,'Defense +80',0,0,80,0,NULL),
('Attack',100,'Attack +20',0,0,0,20,NULL),
('Paladin Sword',1000,'Attack +150 Defence +50',1,0,50,150,1),
('Wizard Wand',1000,'Attack +100, Defence +100',1,0,100,100,2),
('Green Tooth',1000,'+200 Health',1,200,0,0,3),
('Viking Axe',1000,'Attack +150 Defence +50',1,0,50,150,4)


Insert into SubHeroClasses(SubClassName,SubClassLevel,SubClassBonusAttack,SubClassBonusDefense,SubClassBonusHealth,SubClassBonusCoins,ClassId)
values
('Paladin I',1,50,50,50,100,1),
('Paladin II',2,60,60,60,150,1),
('Paladin III',3,100,100,100,200,1),
('Wizard I',1,50,50,50,100,2),
('Wizard II',2,60,60,60,150,2),
('Wizard III',3,100,100,100,200,2),
('Druid I',1,50,50,50,100,3),
('Druid II',2,60,60,60,150,3),
('Druid III',3,100,100,100,200,3),
('Viking I',1,50,50,50,100,4),
('Viking II',2,60,60,60,150,4),
('Viking III',3,100,100,100,200,4)

Insert into Stories([Name])
values
('Story I'),
('Story II'),
('Story III'),
('Story IV'),
('Story V')

