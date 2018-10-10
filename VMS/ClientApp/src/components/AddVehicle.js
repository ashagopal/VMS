﻿import React, { Component } from 'react'
import { Form, FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap'

export default class AddVehicle extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { attributes: [] },  
            vehicleData: {make:'', model:'',attributes:[]}
        };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = { attributes: [] };
        for (var i = 0; i < event.target.length - 1; i++) {
            data.vehicleTypeId = this.props.match.params.typeid;
            switch (event.target[i].name) {
                case "make":
                    data.make = event.target[i].value; break;
                case "model":
                    data.model = event.target[i].value; break;
                default:
                    data.attributes.push({
                        key: event.target[i].name,
                        value: event.target[i].value
                    });
            }
        }
        
        fetch('/api/vehicle/add-vehicle', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
    }

    componentDidMount() {
       
        fetch("/api/vehicle/add-vehicle/" + this.props.match.params.typeid)
            .then(res => res.json())
            .then(
                (result) => {
                    console.log(result);
                    this.setState({
                        data: result
                    });

                },
                (error) => {
                    console.log(error);

                }
        )

        fetch("/api/vehicle/" + this.props.match.params.typeid + '/' + this.props.match.params.id)
            .then(res => res.json())
            .then(
                (result) => {
                    console.log(result);
                    this.setState({
                        vehicleData: result
                    });

                },
                (error) => {

                }
            )

    }

    render() {
        
        return (
            <div>
                <h1>{this.props.match.params.id ? 'Edit' : 'Add'} vehicle</h1>

                <Form onSubmit={this.handleSubmit}>
                    <FormGroup controlId="formMake">
                        <ControlLabel>Make</ControlLabel>{' '}
                        <FormControl type="text" placeholder="Make" name="make" value={this.state.vehicleData.make} />
                    </FormGroup>{''}
                    <FormGroup controlId="formModel">
                        <ControlLabel>Model</ControlLabel>{' '}
                        <FormControl type="text" placeholder="Model" name="model" value={this.state.vehicleData.model} />
                    </FormGroup>{' '}
                    {
                        this.state.data.attributes.map(
                            (attr, index) => {
                                return (
                                    <FormGroup key={index} controlId={attr.Name}>
                                        <ControlLabel>{attr.uiName}</ControlLabel>{' '}
                                        {
                                            this.state.vehicleData.attributes && this.state.vehicleData.attributes.find(q => q.key == attr.name)
                                                ? <FormControl type="text" placeholder={attr.uiName} name={attr.id}
                                                    value={this.state.vehicleData.attributes.find(q => q.key == attr.name).value} />
                                                : <FormControl type="text" placeholder={attr.uiName} name={attr.id} />
                                        }
                                    </FormGroup>
                                );
                            }
                        )
                    }

                    <Button type="submit">Submit</Button>
                </Form>
            </div>
        );

    }
}