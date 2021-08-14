# UNS - Testing Automation Tools

## Implementación en cypress:

### Configuración:
1. Cree un archivo cypress.json dentro de la carpeta **\cypress**.
* Complete los valores con la información necesaria para acceder a la base de datos y la url base del FMS Web Portal correspondiente al environment elegido. 
2. Cree un archivo envValues.json dentro de la carpeta **\cypress\cypress\fixtures**
* Complete los datos necesarios para el login del usuario.

### Ejecución:
En una consola de comandos ejecutar el siguiente comando:
```
./node_modules/.bin/cypress open
```
