import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { BusinessService } from 'app/config/business.service';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html',
    styleUrls: []
})

export class ClienteComponent implements OnInit {

    clienteSeleccionado = {};
    clientes = [];
    canSubmit = false;

    constructor(private backend: BusinessService, private modalService: NgbModal) { }

    ngOnInit() {
        this.backend.getClientes().then((data: []) => {
            this.clientes = data;
            this.canSubmit = true;
        });
    }

    onSubmit(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;

            var toSubmit = f.value;

            this.backend.saveCliente(toSubmit).then(x => {
                this.clientes.push(x);
                f.resetForm();

                this.canSubmit = true;
            }).catch(err => {
                alert(err.error[0].errorMessage);
                this.canSubmit = true;
            })
        }
    }

    openModal(content, cliente) {
        this.clienteSeleccionado = cliente;
        this.modalService.open(content);
    }

    onSubmitUpdate(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;
            this.backend.updateCliente(f.value).then((x: any) => {
                var index = this.clientes.findIndex(item => item.id === x.id)
                this.clientes.splice(index, 1, x)

                this.canSubmit = true;
            }).catch(err => {
                alert(err.error[0].errorMessage);
                this.canSubmit = true;
            })
        }
    }

}
