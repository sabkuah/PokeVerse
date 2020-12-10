# The PokeVerse App v1

## App Description

This application is designed for users ("trainers") to be able to store their pokemon collections via a searchable and browsable database. In Version 1.0 we include the original 150 pokemon and the ability to save your collection and share it via social media. In later versions, we hope to implement trainer "levels" and a trading and game aspect

## Installation Instructions

Clone this repo locally. Copy the appsettingsTEMPLATE.json to a file called appsettings.json. Update your connection string to point to your database. Register your site with google here [here](https://https://www.google.com/recaptcha/) to add authentication. Add your site and secret keys to your appsettings.json. Run`Add-Migration InitialPokeVerseSchema -Context PokeVerseDbContext -OutputDir "Data/PokeMigrations"` and then run `Update-Database`. Build your project and launch.  

### Trouble Shooting

If the build fails, ensure that you have the PaulMiami Recaptcha V2 and bootstrap packages installed. 

## Functional Requirements

### Backend 
- Authentication for user accounts
    - Recaptcha and/or two-factor
    - Email confirmation
- Seed populated database

### Frontend
- Pages/Views: See moqup
- User must be able to register or login
- User must be able to add or delete pokemon from their collection
- User must be able to view catalogue of pokemon

## Non-functional Requirements
- Usability: CRAP principles, documentation
- Preformance: Implement rate limits if preformance becomes an issue

## Features

### Must Haves
- User login/authentication
- Browsable Pokemon database
- Pokedex Storage using CRUD

### Nice To Haves
#### Level 1 Nice To Haves
- Search/filter functionality
- Social media sharing functionality
- Wishlist

#### Level 2 Nice To Haves
- Trainer profiles
- Trainer levels
- Ability to trade cards
- In game currency
- Ability to "play pokemon"

## Prototypes
![](https://i.imgur.com/fqVEAml.png)
![](https://i.imgur.com/9QKPLYo.png)
![](https://i.imgur.com/dZ1ZKHX.png)
![](https://i.imgur.com/fE8rkqS.png)
![](https://i.imgur.com/7oZyssQ.png)
![](https://i.imgur.com/lHhqLd2.png)



## ERD
![](https://i.imgur.com/HmHVeNg.png)

