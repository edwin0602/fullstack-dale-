import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import {AutocompleteLibModule} from 'angular-ng-autocomplete';

import { ClienteComponent } from './cliente/cliente.component';
import { ProductoComponent } from './producto/producto.component';
import { VentasComponent } from './ventas/ventas.component';
import { HistoricoComponent } from './historico/historico.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbModule,

        AutocompleteLibModule
    ],
    declarations: [
        ProductoComponent,
        ClienteComponent,
        VentasComponent,
        HistoricoComponent
    ]
})
export class BusinessModule { }