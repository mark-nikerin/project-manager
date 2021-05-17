import React from 'react';
import { NavLink } from 'react-router-dom';
import { Avatar, Menu, Dropdown, Space, Input, Typography, Divider, Button} from 'antd';
import { DownOutlined, ProjectOutlined, MenuOutlined } from '@ant-design/icons';

import styles from './Header.module.css';

const { Search } = Input;
const { Text } = Typography;
const onSearch = value => console.log(value);

var Header = () => {

  return (
    <nav className={styles.header}>
      <Space align="center" size="middle">
        <NavLink exact activeClassName="active" to="/">
          <Space align="center">
            <ProjectOutlined style={{ fontSize: "28px", marginTop: "5", color: "#2F80ED" }} />
            <Text strong style={{ fontSize: "24px", color: "#2F80ED" }}>Project Manager</Text>
          </Space>
        </NavLink>
        <Text strong style={{ fontSize: "28px", marginLeft: "100px"  }}>Best Project</Text>
        <Divider type="vertical" />
        <NavLink activeClassName="active" to="/projects">
          <Button icon={<MenuOutlined style={{ fontSize: "14px" }} />} style={{ backgroundColor: "#F2F2F2", borderRadius: "5px" }}>Все проекты</Button>
        </NavLink>
      </Space>
      <Space size="middle">
        <Search placeholder="Поиск" onSearch={onSearch} style={{ width: 350 }} allowClear enterButton="Найти" />
        <Space size="middle">
          <Divider type="vertical" />
          <Avatar size={36}>МН</Avatar>
          <Dropdown
            overlay={
              <Menu>
                <Menu.Item key="0">
                  <span>Мои задачи</span>
                </Menu.Item>
                <Menu.Item key="1">
                  <span>Моё время</span>
                </Menu.Item>
                <Menu.Divider />
                <Menu.Item key="3">Выход</Menu.Item>
              </Menu>
            }>
            <a className="ant-dropdown-link" onClick={e => e.preventDefault()}>
              Марк Никерин <DownOutlined />
            </a>
          </Dropdown>
        </Space>
      </Space>

    </nav>);
}

export default Header;