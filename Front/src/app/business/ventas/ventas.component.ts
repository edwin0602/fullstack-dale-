import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { BusinessService } from 'app/config/business.service';

@Component({
    selector: 'app-venta',
    templateUrl: './ventas.component.html',
    styleUrls: []
})

export class VentasComponent implements OnInit {

    @ViewChild('confirmModal', { static: false }) private confirmModal;

    productos = [];
    clientes = [];

    factura = {
        detalleFactura: [],
        cliente: {} as Cliente,
        valorTotal: 0
    };

    canSubmit = false;

    constructor(private backend: BusinessService, private modalService: NgbModal) { }

    ngOnInit() {
        this.backend.getProductos().then((data: []) => {
            this.productos = data;
            return this.backend.getClientes();
        }).then((data: []) => {
            this.clientes = data;
            this.canSubmit = true;
        })
    }

    onAddItem(f: NgForm) {
        if (f.valid) {

            var toAdd = f.value;
            toAdd.valor = toAdd.cantidad * toAdd.producto.valorUnitario;

            this.deleteIten(toAdd.producto.id);

            this.factura.detalleFactura.push(f.value)
            this.calculateTotal();
            f.resetForm();
        }
    }

    deleteIten(id: number) {
        this.factura.detalleFactura =
            this.factura.detalleFactura.filter(item => item.producto.id !== id);

        this.calculateTotal();
    }

    calculateTotal() {
        if (this.factura.detalleFactura.length <= 0) {
            this.factura.valorTotal = 0;
            return;
        }

        this.factura.valorTotal = this.factura.detalleFactura
            .map(item => item.valor)
            .reduce((prev, next) => prev + next);
    }

    selectCliente(item: any) {
        this.factura.cliente = item;
    }

    onSubmit(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;

            var toSubmit = {
                clienteId: this.factura.cliente.id,
                detalles: this.factura.detalleFactura.map(item => ({ productoId: item.producto.id, cantidad: item.cantidad }))
            }

            this.backend.saveFactura(toSubmit).then(x => {
                this.modalService.open(this.confirmModal);
                this.canSubmit = true;
            }).catch(err => {
                alert(err.error[0].errorMessage);
                this.canSubmit = true;
            })
        }
    }

}
