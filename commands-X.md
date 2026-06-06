Router Siege
```
en
conf t
hostname Siege

interface g0/0
no shut

interface g0/0.11
encapsulation dot1Q 11
ip address 10.X.11.1 255.255.255.0
ip nat inside

interface g0/0.22
encapsulation dot1Q 22
ip address 10.X.22.1 255.255.255.0
ip nat inside

interface g0/0.33
encapsulation dot1Q 33 native
ip address 10.X.33.1 255.255.255.0
ip nat inside

interface s0/0/0
ip address 1.X.0.1 255.255.255.252
ip nat outside
no shut

ip dhcp excluded-address 10.X.11.1 10.X.11.20
ip dhcp excluded-address 10.X.22.1 10.X.22.20
ip dhcp excluded-address 10.X.33.1 10.X.33.20

ip dhcp pool VLAN11
network 10.X.11.0 255.255.255.0
default-router 10.X.11.1
dns-server 60.X.0.2

ip dhcp pool VLAN22
network 10.X.22.0 255.255.255.0
default-router 10.X.22.1
dns-server 60.X.0.2

ip dhcp pool VLAN33
network 10.X.33.0 255.255.255.0
default-router 10.X.33.1
dns-server 60.X.0.2

access-list 1 permit 10.X.22.0 0.0.0.255
access-list 1 permit 10.X.33.0 0.0.0.255

ip nat inside source list 1 interface s0/0/0 overload

ip route 0.0.0.0 0.0.0.0 1.X.0.2

end
wr
```

Router Ouest
```
en
conf t
hostname Ouest

interface s0/0/0
ip address 1.0.0.1 255.255.255.252
no shut

interface g0/0
ip address 2.X.0.1 255.255.0.0
no shut

interface g0/1
ip address 8.0.0.1 255.0.0.0
ip ospf authentication message-digest
ip ospf message-digest-key 1 md5 CmMO2026
no shut

router ospf 1
network 1.0.0.0 0.0.0.3 area 0
network 2.X.0.0 0.0.255.255 area 0
network 8.0.0.0 0.255.255.255 area 0

end
wr
```

Router Sud
```
en
conf t
hostname Sud

interface g0/0
ip address 8.0.0.4 255.0.0.0
ip ospf authentication message-digest
ip ospf message-digest-key 1 md5 CmMO2026
no shut

interface g0/1
ip address 5.X.0.1 255.255.0.0
no shut

router ospf 1
network 5.X.0.0 0.0.255.255 area 0
network 8.0.0.0 0.255.255.255 area 0
end
wr
```

Router Est
```
en
conf t
hostname Est

interface g0/1
ip address 8.0.0.3 255.0.0.0
ip ospf authentication message-digest
ip ospf message-digest-key 1 md5 CmMO2026
no shut

interface g0/0
ip address 4.X.0.1 255.255.0.0
no shut

router ospf 1
network 4.X.0.0 0.0.255.255 area 0
network 8.0.0.0 0.255.255.255 area 0
end
wr
```

Router Nord
```
en
conf t
hostname Nord

interface g0/1
ip address 8.0.0.2 255.0.0.0
ip ospf authentication message-digest
ip ospf message-digest-key 1 md5 CmMO2026
no shut

interface g0/0
ip address 3.X.0.1 255.255.0.0
no shut

router ospf 1
network 3.X.0.0 0.0.255.255 area 0
network 8.0.0.0 0.255.255.255 area 0
end
wr
```

Router Filiale
```
en
conf t
hostname Filiale

interface g0/0
ip address 4.X.0.2 255.255.255.252
ip nat outside
no shut

interface g0/1
ip address 192.168.X.65 255.255.255.192
ip nat inside
no shut

access-list 1 permit 192.168.X.64 0.0.0.63

ip nat inside source list 1 interface g0/0 overload

ip route 0.0.0.0 0.0.0.0 4.X.0.1

end
wr
```

Router Siege
```
en
conf t

interface g0/1
ip address 60.X.0.1 255.255.255.240
no shut

end
wr
```

Router Siege
```
en
conf t

router ospf 1
area 0 authentication message-digest
network 1.X.0.0 0.0.0.3 area 0
network 10.X.0.0 0.0.255.255 area 0
network 60.X.0.0 0.0.0.15 area 0

interface s0/0/0
ip ospf message-digest-key 1 md5 CmMO2026

end
wr
```

Router Ouest
```
en
conf t

interface s0/0/0
ip ospf message-digest-key 1 md5 CmMO2026

router ospf 1
area 0 authentication message-digest

end
wr
```

Router Filiale
```
en
conf t

ip dhcp excluded-address 192.168.X.65 192.168.X.70

ip dhcp pool DHCP_Filiale
 network 192.168.X.64 255.255.255.192
 default-router 192.168.X.65
 dns-server 60.X.0.2

end
wr
```

Switch Multilayer
```
en
conf t

vlan 11
name Employees

vlan 22
name Direction

vlan 33
name IT

interface fa0/15
switchport trunk encapsulation dot1q
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/16
switchport trunk encapsulation dot1q
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface gig0/1
switchport trunk encapsulation dot1q
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface gig0/2
switchport trunk encapsulation dot1q
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

end
wr
```

Switch A1
```
en
conf t

vlan 11
name Employees

vlan 22
name Direction

vlan 33
name IT

interface range fa0/1-9
switchport access vlan 22
switchport mode access

interface range fa0/10-17
switchport access vlan 11
switchport mode access

interface fa0/18
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/20
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/23
switchport access vlan 33
switchport mode access

interface fa0/24
switchport access vlan 33
switchport mode access

end
wr
```

Switch A2
```
en
conf t

vlan 11
name Employees

vlan 22
name Direction

vlan 33
name IT

interface range fa0/1-9
switchport access vlan 22
switchport mode access

interface range fa0/10-17
switchport access vlan 11
switchport mode access

interface fa0/19
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/20
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/22
switchport trunk native vlan 33
switchport trunk allowed vlan 11,22,33
switchport mode trunk

interface fa0/21
switchport access vlan 33
switchport mode access

end
wr
```

Prtie 2 ACL
Router Siege
```
en
conf t

username admin privilege 15 secret CmMO2026

ip domain-name votre-nom.ca

crypto key generate rsa
1024

ip ssh version 2

ip access-list standard SSH-IT-ONLY
 permit 10.X.33.0 0.0.0.255
 deny any

line vty 0 4
 access-class SSH-IT-ONLY in
 login local
 transport input ssh

login block-for 120 attempts 3 within 60
login on-failure log
login on-success log

end
wr
conf t

ip access-list extended ACL-IT
 permit ip 10.X.33.0 0.0.0.255 any

end
wr

conf t

ip access-list extended ACL-DIRECTION

permit udp any host 255.255.255.255 eq bootps
permit udp any any eq bootps
permit udp any any eq bootpc

permit udp 10.X.22.0 0.0.0.255 host 60.X.0.2 eq domain
permit tcp 10.X.22.0 0.0.0.255 host 60.X.0.2 eq domain

permit tcp 10.X.22.0 0.0.0.255 host 60.X.0.3 eq www
permit tcp 10.X.22.0 0.0.0.255 host 60.X.0.3 eq 443

deny ip 10.X.22.0 0.0.0.255 any

end
wr
ex
```