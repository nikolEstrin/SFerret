import Nav from 'react-bootstrap/Nav';
import "./OptionsList.css";

function OptionsList() {


    return(
        <Nav id='upper_tab' fill variant="tabs" defaultActiveKey="/" className='fixed-top bg-dark navbar-dark'>
        <Nav.Item>
          <Nav.Link eventKey="disabled" className='link' disabled>Hello UserFullName</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/WatchList" className='link'>WatchList</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/Feed" className='link'>Feed</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/Search" className='link'>Search</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link eventKey="disabled" className='link' disabled>Disabled</Nav.Link>
        </Nav.Item>
        </Nav>
    );
}

export default OptionsList;
