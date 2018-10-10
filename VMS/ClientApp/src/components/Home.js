import React, { Component } from 'react';
import { Table, Button, DropdownButton, MenuItem } from 'react-bootstrap'
import { Redirect } from 'react-router-dom'
import AddVehicle from './AddVehicle';
import Spinner from './Spinner';

export default class Home extends Component {

    constructor(props) {
        super(props);
        this.AddVehicleClicked = this.AddVehicleClicked.bind(this);
        this.EditVehicleClicked = this.EditVehicleClicked.bind(this);
        this.state = {
            loading:false,
            data: {
                vehicles: [{ attributes: [] }],
                vehicleType: [],
                vehicleAttributes:[]
            },
            selectedVehicleType: 1
        }
    }

    AddVehicleClicked() {
        this.props.history.push('/add-vehicle/' + this.state.selectedVehicleType);
    }

    EditVehicleClicked(id) {
        this.props.history.push('/edit-vehicle/' + this.state.selectedVehicleType + '/' +id);
    }

    componentDidMount() {
        this.setState({ loading: true });
        fetch("https://localhost:44326/api/home/" + this.state.selectedVehicleType)
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
                    //console.log(error);

                }
        )
    }
    render() {

        return (
            <div>
                <Spinner showLoading={this.state.loading}></Spinner>
                <h1>Vehicle Management System</h1>
                
                <Button bsStyle="success" onClick={this.AddVehicleClicked}>New Vehicle</Button>

                <Table responsive>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Make</th>
                            <th>Model</th>
                            {
                                this.state.data.vehicleAttributes.map((attribute, index) => {
                                    return (
                                        <th key={index}>{attribute.uiName}</th>
                                    )
                                })
                            }
                            <th>Action</th>
                        </tr>
                    </thead>

                    <tbody>
                        {
                            this.state.data.vehicles.map((p, index) => {
                                return (
                                <tr key={index}>
                                    <td>{p.id}</td>
                                    <td>{p.make}</td>
                                    <td>{p.model}</td>
                                    {
                                            this.state.data.vehicleAttributes.map((attribute, index) => {
                                                return (
                                                    <td key={index}>
                                                        {
                                                            p.attributes.find(q => q.key == attribute.name)
                                                            ? p.attributes.find(q => q.key == attribute.name).value
                                                            : ''
                                                        }
                                                    </td>
                                            )
                                        })
                                    }
                                    <td><a href="javascript:void(0)" onClick={() => this.EditVehicleClicked(p.id)}>Edit</a></td>
                                </tr>)
                            })
                        }
                    </tbody>


                </Table>
               
            </div>
        );
    }
}


