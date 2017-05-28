import * as React from 'react';

export interface IAppProps {
    navMenu: React.ReactElement<any>;
    topMenu: React.ReactElement<any>;
    layout: React.ReactElement<any>;
    divStylePageWrapper: { minHeight: '346px' }
}

export default class App extends React.Component<IAppProps, void> {

    public render() {
        return <div>                                      
                       {this.props.navMenu}                   
                   <div id="page-wrapper" className="gray-bg dashbard-1" style={this.props.divStylePageWrapper}>                       
                       <div className="row border-bottom">
                           {this.props.topMenu}
                       </div>                       
                       {this.props.layout}
                   </div>
               </div>;
    }
}