# TeaApi
## Idea Changes
The store and tea tables remained the same. However, the idea behind it changed. I made a mistake since I didn't take into account that store_id was a primary key and that there are no arrays in MySql. So the stores will only contain their most popular tea and will be a child of the tea table. The idea behind this is that you cannot get rid of a tea if there are still stores selling it.

## Instructions
### Endpoints
- **GET** *api/store*
- **POST** *api/store*
- **PUT** *api/store/{id}*

### Sample Request Bodies
- None
### Sample Response Body
- {"StatusCode": 404, "StatusDescription": "Not Found", Store: null}
