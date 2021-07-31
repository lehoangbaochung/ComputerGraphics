#include<Windows.h>
#include<stdio.h>
#include<GL/glut.h>
#include<GL/gl.h>
#include<GL/glu.h>
#include <iostream>

using namespace std;
float spin = 0;

void drawCoordinate()
{
	glDisable(GL_LIGHTING);

	glBegin(GL_LINES); //OX
	glColor3f(1.0, 0.0, 0.0);
	glVertex3f(0.0, 0.0, 0.0);
	glVertex3f(10.0, 0.0, 0.0);
	glEnd();

	glBegin(GL_LINES); //OY
	glColor3f(0.0, 1.0, 0.0);
	glVertex3f(0.0, 0.0, 0.0);
	glVertex3f(0.0, 10.0, 0.0);
	glEnd();

	glBegin(GL_LINES); //OZ
	glColor3f(0.0, 0.0, 1.0);
	glVertex3f(0.0, 0.0, 0.0);
	glVertex3f(0.0, 0.0, 20.0);
	glEnd();
	glBegin(GL_LINES); //OZ
	glColor3f(0.0, 1.0, 0.0);
	glVertex3f(0.0, -10.0, 0.0);
	glVertex3f(0.0, 0.0, 0.0);
	glEnd();

	glEnable(GL_LIGHTING);
}

void draw() {
	glClearColor(1, 1, 1, 0);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glLoadIdentity();
	gluLookAt(5.0, 5.0, 15.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
	DrawCoordinate();

	//hình gốc
	glPushMatrix();

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_DEPTH_TEST);

	GLfloat light_pos1[] = { 0.0, 1.0, 1.0, 0.0 };  //Vị trí ánh sáng chiếu vào
	glLightfv(GL_LIGHT0, GL_POSITION, light_pos1);

	GLfloat ambient1[] = { 1.0, 1.0, 0.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, ambient1); //Chiếu ánh sáng toàn phần của đối tượng

	GLfloat diff_use1[] = { 1.0, 0.5, 1.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, diff_use1); //Tạo ánh sáng khuếch tán cho đối tượng

	GLfloat specular1[] = { 1.0, 1.0, 1.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, specular1); //Tạo ánh sáng phản xạ trong đối tượng

	GLfloat shininess1 = 30.0f;
	glMateriali(GL_FRONT, GL_SHININESS, shininess1); //Điều chỉnh cường độ điểm chiếu sáng phản xạ

	//glTranslatef(-4, 0, 0);
	glRotatef(-spin, 0, 0, 1);
	glutSolidCube(2.0);

	//hình 1
	glPopMatrix();
	glPushMatrix();

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_DEPTH_TEST);

	GLfloat light_pos11[] = { 1.0, 1.0, 0.0, 0.0 };  //Vị trí ánh sáng chiếu vào
	glLightfv(GL_LIGHT0, GL_POSITION, light_pos11);

	GLfloat ambient11[] = { 1.0, 1.0, 0.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, ambient11); //Chiếu ánh sáng toàn phần của đối tượng

	GLfloat diff_use11[] = { 1.0, 0.0, 0.5, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, diff_use11); //Tạo ánh sáng khuếch tán cho đối tượng

	GLfloat specular11[] = { 1.0, 1.0, 1.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, specular11); //Tạo ánh sáng phản xạ trong đối tượng

	GLfloat shininess11 = 30.0f;
	glMateriali(GL_FRONT, GL_SHININESS, shininess11); //Điều chỉnh cường độ điểm chiếu sáng phản xạ

	glTranslatef(0, -4, 0);
	glRotatef(-spin, 0, 1, 0);

	glutSolidCube(2.0);
	glPopMatrix();
	glPushMatrix();

	//hình 2
	glLoadIdentity();

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_DEPTH_TEST);

	GLfloat light_pos[] = { 0.0, 0.0, 1.0, 0.0 };  //Vị trí ánh sáng chiếu vào
	glLightfv(GL_LIGHT0, GL_POSITION, light_pos);

	GLfloat ambient[] = { 1.0, 1.0, 0.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, ambient); //Chiếu ánh sáng toàn phần của đối tượng

	GLfloat diff_use[] = { 0.5, 1.0, 0.5, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, diff_use); //Tạo ánh sáng khuếch tán cho đối tượng

	GLfloat specular[] = { 1.0, 1.0, 1.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, specular); //Tạo ánh sáng phản xạ trong đối tượng

	GLfloat shininess = 30.0f;
	glMateriali(GL_FRONT, GL_SHININESS, shininess); //Điều chỉnh cường độ điểm chiếu sáng phản xạ

	glPopMatrix();
	glTranslatef(0, 4, 0);
	glRotatef(spin, 0, 1, 0);

	glutSolidCube(2.0);

	spin += 0.3;// tăng góc
	if (spin > 360)
	{
		spin = spin - 360;
	}

	glutSwapBuffers();
	glutPostRedisplay();
	glFlush();
}

void ReShape(int w, int h)
{
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	float ratio = (float)w / (float)h;
	gluPerspective(45.0, ratio, 1, 100.0);
	//glOrtho(-10.0, 10.0, -10.0, 10.0, 10.0, -10.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(5.0, 5.0, 15.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGB);
	glutInitWindowSize(500, 500);
	glutCreateWindow("Test");
	//Init();
	glutDisplayFunc(draw);
	glutReshapeFunc(ReShape);
	glutMainLoop();
}
