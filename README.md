# Biuro

Konfiguracja:
Tworzymy bazę danych o nazwie BiuroPodrozy w 

- W pliku appsettings.json zmieniamy wartości w ConnectionString: 
Data: W DATA SOURCE zamieniamy DESKTOP-KURUF8P na nazwę servera  MS SQL
Data2 W SERVER zamieniamy DESKTOP-KURUF8P  na nazwę servera  MS SQL

Następnie w konsoli menedżera pakietów uruchamiamy:

update-database -verbose -context applicationdbcontext

update-database -verbose -context appidentitydbcontext

Przykładowe dane w sql:
Insert Into Ph
Values ('Cypr.jpg'), ('Egipt.jpg')

Insert Into Data
Values ('Egipt', 2250, 12, '2023-12-11', 2), 
('Cypr', 1780, 12, '2022-09-10', 1)

Insert Into Dc
Values ('Warszawa'), ('Krakow'), ('Gdansk')

Insert Into BiuroItemDepartureCity
Values(1, 2), (1,3), (2,1)

Dane do logowania:
Admin(Login: Admin, Hasło: Secret123$)
