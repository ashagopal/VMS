import React, {Component } from 'react'

export default class Spinner extends Component {

    constructor(props) {
        super(props);

    }

    render() {

        return (
            this.props.showLoading
                ? <div className="loader-background"><div className="loader"></div></div>
                : ''
            );
    }
}