import xml.etree.ElementTree as et

path = 'C:/Users/Yugan/Documents/GitHub/Leadership-Map-Website/Data/'
et.register_namespace('', 'http://www.gexf.net/1.3')
et.register_namespace('viz', "http://www.gexf.net/1.3/viz") 
tree = et.parse(path + 'no names no zeros.gexf')
root = tree.getroot()

for n in range(len(root[1][1])):
	root[1][1][n][0][0].attrib['value'] = root[1][1][n][0][0].attrib['value'].replace('[','')
	root[1][1][n][0][0].attrib['value'] = root[1][1][n][0][0].attrib['value'].replace(']','')
	root[1][1][n][0][0].attrib['value'] = root[1][1][n][0][0].attrib['value'].replace('"','')

tree.write(path + 'modified.gexf', encoding="utf-8", xml_declaration=True)
