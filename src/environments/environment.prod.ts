import { HttpClient, HttpHeaders } from '@angular/common/http';

export const environment = {
    production: true,
    AUTH_API: 'https://production-api-url',
    httpOptions: {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  };