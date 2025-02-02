# Building a Todo App with ABP Framework and React using the MVC Approach 🚀

This repository contains the code used in my blogs post series on building a Todo App with ABP Framework and React using the MVC approach.

## Demo
[Watch the video](https://vimeo.com/1052594921/2d04e1a838)

## Blog Posts
### Part 1: [Integrating ABP Modules in Your ASP.NET Core Web API Project. A Step-by-Step Guide](https://blogs.sajankumarv.com/integrating-abp-modules-in-your-asp-net-core-web-api-project-a-step-by-step-guide-774c63ef8014)
### Part 2: [Building UI with React using the MVC Approach](https://blogs.sajankumarv.com/building-a-scalable-ui-with-react-abp-framework-and-inertia-js-using-the-mvc-approach-5857f2e0551b)
Feel free to explore, contribute, and share your thoughts!


## How to run the project
### Backend
1. Clone the repository
2. Open the solution file `SimpleTodoApp.sln` in your favorite IDE
3. Run the migration to create the database by running the following command in the Package Manager Console
```bash
dotnet ef database update
```
4. Run the project ```dotnet watch run```


### Frontend

1. Navigate to the `AbpTodoApp` directory
2. Run the following command to install the dependencies
```bash
npm install
```
3. Create a `.env` file in the root directory and add the following environment variables
```bash

APP_URL=https://localhost:7287

```
4. Run the project
```bash
npm run dev
```

