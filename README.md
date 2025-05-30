﻿# Api Cliente Servidor
Api simples sem utilziar banco de dados
## Linguagem usada
C# 13 e ASP.Net  -> NET 9
-> SDK : https://dotnet.microsoft.com/pt-br/download/dotnet/9.0
## Estrutura do projeto
### repository pattern
CarRepository implementa ICarRepository
### Controllers
CarController -> realiza as operações CRUD atraves do ICarRepository
retorna IActionResult junto ao codigo como response -> 200, 201, 400, 404 500 etc...
### CRUD
#### rota padrao do sistema **``/api/cars``**
Json model **POST :**
```Json
{
    "model": "civic",
    "mileage": 15000,
    "price": 24000,
    "year": 1997,
    "description": "em bom estado"
} 
```

| Método | Rota                   | Descrição                                                                 |
|--------|------------------------|---------------------------------------------------------------------------|
| POST    | `/api/cars`       | Cria um carro atraves do body|
| PUT    | `/api/cars/{id}`       | Atualiza um carro pelo ID. Todos os atributos devem ser informados no body. |
| DELETE | `/api/cars/{id}`       | Remove um carro pelo ID informado na rota.                                |
| GET    | `/api/cars`            | Retorna a lista de carros (rota padrão do sistema).                      |
| GET    | `/api/cars/{id}`       | Retorna um carro específico pelo ID.                                     |


#### Validação
| Campo        | Validação                          |
|--------------|-----------------------------------|
| model        | Máximo de 40 caracteres           |
| year         | Entre 1931 e 2025                 |
| price        | Obrigatório (`Required`)          |
| mileage      | Obrigatório (`Required`)          |
| description  | Máximo de 225 caracteres          |

### Persistencia
O repository trata um Dictonary<Car> como base de dados e escreve em um json ou apaga do mesmo antes de retornar o valor esperado, se o json ja existir o mesmo é desserializado e lido pelo Dictonary

o mesmo se encontra na **``ClienteServidor_Api\ClienteServidor_Api\JsonBase\Car.json``**
**é necessario realiziar ao menos um POST para que o Car.json seja criado**

### Autores
Abner Marins Prudencio, Gustavo Silveira, Fabricio Trindade, Thomas Caires
