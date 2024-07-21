import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private _http: HttpClient) { }
  apiUrl = 'https://localhost:7025/api/Product';
  
  getAllProducts(): Observable<any[]> {
    return this._http.get<any[]>(this.apiUrl);
  }

  getProduct(id: number): Observable<any> {
    return this._http.get<any>(`${this.apiUrl}/${id}`);
  }

  addProduct(product: any): Observable<any> {
    return this._http.post<any>(this.apiUrl, product);
  }

  updateProduct(id: number, product: any): Observable<any> {
    return this._http.put<any>(`${this.apiUrl}/${id}`, product);
  }

  deleteProduct(id: number): Observable<any> {
    return this._http.delete<any>(`${this.apiUrl}/${id}`);
  } 
}
