import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Socials } from "./Socials";

export default props => (
  <div>
    <NavMenu />
    <Socials />
    {/*<Container>*/}
      {props.children}
    {/*</Container>*/}
  </div>
);
