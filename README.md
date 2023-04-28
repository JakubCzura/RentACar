# RentACar

It is a web application to rent a car.

Launching:
1. Download the project and unzip.
2. Open solution RentACar.sln and launch project RentACar.WebAPI.
3. Open directory rent-a-car.ui for example in VS Code.
4. Open new terminal, install npm with "npm install" and launch front-end with "npm start".
5. Important! You may have to enable cors in your browser and need a proper extension to do it. This one helped me, otherwise there might occur an issue with sending requests.

![obraz](https://user-images.githubusercontent.com/76125047/235017129-f770d4d8-6b59-4e72-bf81-4c406003540d.png)

6. That's all! Have a ball!

Project expectations:
1. Client pays for each day, for example May 12-14 is calculated as 3 days, I don't precise exact hour when a car is picked up and returned.
2. Project uses local database created with Entity Framework tools.
3. When user is logged in, their id is stored in localstorage with information authenticated="true". It is just a simple solution by now, it's obvious that it should be implemented with JWT token. Password is hashed and stored in database.
4. I created list of cars in database that are available to rent. When a car is returned it's availability should be set to true, but by now I have just implemented renting a car and marking it as reserved.
5. Important feature is to return more friendly errors' messages to user interface as I use FluentValidation package to validate dto models. It should be implemented soon.

Please text me if something goes wrong and there appear issues. 

![obraz](https://user-images.githubusercontent.com/76125047/235016022-639b8416-c1c7-4744-899d-be10d5190ba1.png)
![obraz](https://user-images.githubusercontent.com/76125047/235016113-fd94a64f-451e-4b00-b5ff-8ff64d957105.png)
![obraz](https://user-images.githubusercontent.com/76125047/235016190-00b5bfbe-c683-4f3b-81d1-c38d51af63ca.png)
![obraz](https://user-images.githubusercontent.com/76125047/235016243-834b3d07-5f6f-4815-97c1-de505a55f029.png)
![obraz](https://user-images.githubusercontent.com/76125047/235016274-9d5b0d9e-abd8-45ab-bcbd-e3e9be87f569.png)



