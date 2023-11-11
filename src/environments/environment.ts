import { HttpClient, HttpHeaders } from '@angular/common/http';

export const environment = {
    production: false,
    AUTH_API: 'https://localhost:7167',
    httpOptions: {
      headers: new HttpHeaders({ 'Content-Type': 'application/json',
      accept: 'text/plain'})
      
    }
  };