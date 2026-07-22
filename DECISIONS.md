This file have the objective of structure and organize the decions made before and during the development of this API

- I have decided to initially only create 4 main entities: user, transaction, category and budget
- The type of categories will be fixed, that is, the users will not have the possibility to create new category 
- The budget will be monthly
- The register and the login will be made by an auth and a JWT token
- In the next versions I'm thinking about add a relatory feature, so the user can filter expenses, inputs, montlhy, by category, etc what he wants to see


ABOUT THE ENDPOINTS


AUTH
- Register (POST)
- Login (POST)

USER 
- See their data (GET)
- Update data (PUT/PATCH)
- Delete account (DELETE)

TRANSACTION
- List transactions with optional filter by year/month (GET)
- Create transaction (POST)
- Update transaction (PUT/PATCH)
- Delete transaction (DELETE)

CATEGORY
- List categories (GET)

BUDGET 
- See budget (GET)
- Create budget (POST)
- Update budget (PUT/PATCH)
- Will not be possible to delete the budget