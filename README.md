# AlertHaven - Sistema de Eventos e Alertas gerados por IoT

## Visão Geral Completa
Sistema integrado para gestão de:
- Dispositivos IoT (sensores ambientais)
- Eventos registrados
- Alertas gerados
- Interface administrativa web

## Rotas da API Detalhadas

### IoT Controller
| Método | Endpoint               | Parâmetros               | Status Codes          | Descrição |
|--------|------------------------|--------------------------|-----------------------|-----------|
| `GET`  | `/api/iot`             | -                        | 200 OK               | Lista todos dispositivos (simplificado) |
| `GET`  | `/api/iot/{id}`        | `id` (path)              | 200 OK, 404 Not Found | Detalhes completos do dispositivo |
| `POST` | `/api/iot`             | JSON (Body)              | 201 Created, 400 Bad Request | Cadastra novo dispositivo |
| `PUT`  | `/api/iot/{id}`        | `id` + JSON (Body)       | 200 OK, 404 Not Found | Atualização completa |
| `DELETE` | `/api/iot/{id}`      | `id` (path)              | 204 No Content, 404 Not Found | Remove dispositivo |

### Evento Controller
| Método | Endpoint               | Parâmetros               | Status Codes          | Descrição |
|--------|------------------------|--------------------------|-----------------------|-----------|
| `GET`  | `/api/evento`          | -                        | 200 OK               | Lista todos eventos (simplificado) |
| `GET`  | `/api/evento/{id}`     | `id` (path)              | 200 OK, 404 Not Found | Detalhes completos do evento |
| `GET`  | `/api/evento/iot/{IdIot}` | `IdIot` (path)        | 200 OK, 404 Not Found | Eventos por dispositivo IoT |
| `POST` | `/api/evento`          | JSON (Body)              | 201 Created, 400 Bad Request | Registra novo evento |
| `PATCH` | `/api/evento/{id}`    | `id` + JSON (Body)       | 200 OK, 404 Not Found | Atualização parcial |
| `DELETE` | `/api/evento/{id}`   | `id` (path)              | 204 No Content, 404 Not Found | Remove evento |

### Alerta Controller
| Método | Endpoint               | Parâmetros               | Status Codes          | Descrição |
|--------|------------------------|--------------------------|-----------------------|-----------|
| `GET`  | `/api/alerta`          | -                        | 200 OK               | Lista todos alertas |
| `GET`  | `/api/alerta/{id}`     | `id` (path)              | 200 OK, 404 Not Found | Detalhes do alerta |
| `GET`  | `/api/alerta/evento/{IdEvento}` | `IdEvento` (path) | 200 OK, 404 Not Found | Alertas por evento |
| `POST` | `/api/alerta`          | JSON (Body)              | 201 Created, 400 Bad Request | Cria novo alerta |
| `PATCH` | `/api/alerta/{id}`    | `id` + JSON (Body)       | 200 OK, 404 Not Found | Atualiza alerta |
| `DELETE` | `/api/alerta/{id}`   | `id` (path)              | 204 No Content, 404 Not Found | Remove alerta |

## Resumo das Funcionalidades por View

### Home
| View  | Funcionalidades Principais |
|-------|---------------------------|
| Index | Acesso rápido aos módulos<br>- Visão geral do sistema |

### IoT
| View   | Funcionalidades Principais |
|--------|---------------------------|
| Index  | - Mostrar todos os IoTs cadastrados |
| Create | - Validação em tempo real<br>- Dropdowns dinâmicos |
| Details| - Visualização completa<br>- Dados técnicos |
| Edit   | - Edição contextual |
| Delete | - Confirmação segura |

###  Evento
| View   | Funcionalidades Principais |
|--------|---------------------------|
| Index  | - Mostrar todos os eventos cadastrados |
| Create | - Validação em tempo real<br>- Dropdowns dinâmicos |
| Details| - Visualização completa<br>- Dados técnicos |
| Edit   | - Edição contextual |
| Delete | - Confirmação segura |

### Alerta
| View   | Funcionalidades Principais |
|--------|---------------------------|
| Index  | - Mostrar todos os alertas cadastrados |
| Create | - Validação em tempo real<br>- Dropdowns dinâmicos |
| Details| - Visualização completa<br>- Dados técnicos |
| Edit   | - Edição contextual |
| Delete | - Confirmação segura |

## Configuração

```bash
# Clonar repositório
git clone https://github.com/vitorvhsilva/AlertHaven-dotNet
cd AlertHaven

# Configurar conexão com o banco
cp appsettings.Development.json.example appsettings.Development.json
# Editar arquivo com suas credenciais

# Instalar dependências
dotnet restore

# Aplicar migrações
dotnet ef database update
```

## Diagrama

```mermaid
graph TD
    subgraph Frontend
        A[Browser] --> B[ASP.NET Core MVC]
        B --> C[Razor Pages]
    end

    subgraph Backend
        B --> F[Controllers]
        F --> G[Use Cases]
        G --> H[Domain Layer]
        H --> I[Infrastructure]
        I --> Z[(Oracle Database)]
    end

    subgraph Dispositivos
        J[Sensor Temperatura] -->|HTTP| B
        K[Anemômetro] -->|HTTP| B
        L[Sensor Nível Água] -->|HTTP| B
        M[Sismografo] -->|HTTP| B
    end

    style A fill:#4CAF50,stroke:#388E3C
    style B fill:#2196F3,stroke:#0D47A1
    style I fill:#FF5722,stroke:#E64A19
    style J,K,L,M fill:#9C27B0,stroke:#7B1FA2
```

## Dependências
| Componente       | Tecnologia/Pacote           | 
|------------------|-----------------------------|
| ORM              | Entity Framework Core       | 
| Banco de Dados   | Oracle Database             | 
| Mapeamento       | AutoMapper                  | 
| Documentação     | Swashbuckle.AspNetCore      | 
| Interface        | Razor Pages                 | 

