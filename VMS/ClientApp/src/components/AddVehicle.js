﻿import React, { Component } from 'react'
import { Form, FormGroup, ControlLabel, FormControl, Button, Alert } from 'react-bootstrap'
import Spinner from './Spinner';

export default class AddVehicle extends Component {
    constructor(props) {
        super(props);
        this.state = {
            success: false,
            lodaing: false,
            data: { attributes: [] },
            vehicleData: { make: '', model: '', attributes: [] }
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChangeMake = this.handleChangeMake.bind(this);
        this.handleChangeModel = this.handleChangeModel.bind(this);
        this.handleChangeAttributes = this.handleChangeAttributes.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = { attributes: [] };
        for (var i = 0; i < event.target.length - 1; i++) {
            data.vehicleTypeId = this.props.match.params.typeid;
            data.id = this.props.match.params.id;
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
        this.setState({ loading: true });

        fetch('/api/vehicle/add-vehicle', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then((result) => {
            this.setState({ loading: false, success: true });

        });
    }


    componentDidMount() {

        this.setState({ loading: true });
        fetch("/api/vehicle/add-vehicle/" + this.props.match.params.typeid)
            .then(res => res.json())
            .then(
                (result) => {
                    console.log(result);
                    this.setState({
                        data: result,
                        loading: false
                    });

                },
                (error) => {
                    console.log(error);

                }
            )

        this.setState({ loading: true });
        fetch("/api/vehicle/" + this.props.match.params.typeid + '/' + this.props.match.params.id)
            .then(res => res.json())
            .then(
                (result) => {
                    console.log(result);
                    this.setState({
                        vehicleData: result,
                        loading: false
                    });

                },
                (error) => {

                }
            )

    }
    handleChangeMake(event) {
        this.setState({ vehicleData: { make: event.target.value } });
    }

    handleChangeModel(event) {
        this.setState({ vehicleData: { model: event.target.value } });
    }

    handleChangeAttributes(event, name) {
        var updatedAttributes = this.state.vehicleData.attributes.map((q) => {
            if (q.key == name) {
                q.value = event.target.value;
            }
            return q;
        }
        );

        this.setState({ vehicleData: { attributes: updatedAttributes } });
    }


    render() {

        return (
            <div>
                <Spinner showLoading={this.state.loading}></Spinner>

                <h1>{this.props.match.params.id ? 'Edit' : 'Add'} vehicle</h1>

                {
                    this.state.success
                        ? <Alert bsStyle="success" >
                            <strong>{this.props.match.params.id ? "Vehicle data updated" : "New Vehicle Added"}</strong> Please click <a href="/">here</a> to load home screen
                            </Alert>
                        : ''
                }
                <Form onSubmit={this.handleSubmit}>
                    <FormGroup controlId="formMake">
                        <ControlLabel>Make</ControlLabel>{' '}
                        <FormControl type="text" placeholder="Make" name="make" value={this.state.vehicleData.make} onChange={this.handleChangeMake} />
                    </FormGroup>{''}
                    <FormGroup controlId="formModel">
                        <ControlLabel>Model</ControlLabel>{' '}
                        <FormControl type="text" placeholder="Model" name="model" value={this.state.vehicleData.model} onChange={this.handleChangeModel} />
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
                                                    value={this.state.vehicleData.attributes.find(q => q.key == attr.name).value}
                                                    onChange={(e) => { this.handleChangeAttributes(e,attr.name)}}/>
                                                : <FormControl type="text" placeholder={attr.uiName} name={attr.id} />
                                        }
                                    </FormGroup>
                                );
                            }
                        )
                    }
                    {
                        <Button type="submit">Submit</Button>
                    }
                </Form>
            </div>
        );

    }
}