import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ClienteComponent } from './business/cliente/cliente.component';
import { ProductoComponent } from './business/producto/producto.component';
import { VentasComponent } from './business/ventas/ventas.component';
import { HistoricoComponent } from './business/historico/historico.component';

const routes: Routes =[
    { path: '', redirectTo: 'clientes', pathMatch: 'full' },
    { path: 'productos',      component: ProductoComponent },
    { path: 'clientes',      component: ClienteComponent },
    { path: 'ventas',      component: VentasComponent },
    { path: 'historico',      component: HistoricoComponent }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
      useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
