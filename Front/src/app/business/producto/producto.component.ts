import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { BusinessService } from 'app/config/business.service';

@Component({
    selector: 'app-producto',
    templateUrl: './producto.component.html',
    styleUrls: []
})

export class ProductoComponent implements OnInit {

    productoSeleccionado = {};
    productos = [];
    canSubmit = false;

    constructor(private backend: BusinessService, private modalService: NgbModal) { }

    ngOnInit() {
        this.backend.getProductos().then((data: []) => {
            this.productos = data;
            this.canSubmit = true;
        });
    }

    onSubmit(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;

            var toSubmit = f.value;

            this.backend.saveProducto(toSubmit).then(x => {
                this.productos.push(x);
                f.resetForm();

                this.canSubmit = true;
            }).catch(err => {
                alert(err.error[0].errorMessage);
                this.canSubmit = true;
            })
        }
    }


    openModal(content, producto) {
        this.productoSeleccionado = producto;
        this.modalService.open(content);
    }

    onSubmitUpdate(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;
            this.backend.updateProducto(f.value).then((x: any) => {
                var index = this.productos.findIndex(item => item.id === x.id)
                this.productos.splice(index, 1, x)

                this.canSubmit = true;
            }).catch(err => {
                alert(err.error[0].errorMessage);
                this.canSubmit = true;
            })
        }
    }

}
