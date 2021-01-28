import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class BusinessService {

    configUrl = 'https://localhost:44372';

    constructor(private http: HttpClient) { }

    getClientes() {
        return this.http.get(`${this.configUrl}/api/Clientes`).toPromise();
    }

    saveCliente(item: any) {
        return this.http.post(`${this.configUrl}/api/Clientes`, item).toPromise();
    }

    updateCliente(item: any) {
        return this.http.put(`${this.configUrl}/api/Clientes/${item.id}`, item).toPromise();
    }

    getProductos() {
        return this.http.get(`${this.configUrl}/api/Productos`).toPromise();
    }

    saveProducto(item: any) {
        return this.http.post(`${this.configUrl}/api/Productos`, item).toPromise();
    }

    updateProducto(item: any) {
        return this.http.put(`${this.configUrl}/api/Productos/${item.id}`, item).toPromise();
    }

    getFacturas() {
        return this.http.get(`${this.configUrl}/api/Facturas`).toPromise();
    }

    saveFactura(item: any) {
        return this.http.post(`${this.configUrl}/api/Facturas`, item).toPromise();
    }

}